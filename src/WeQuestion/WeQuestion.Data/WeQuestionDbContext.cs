using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using WeQuestion.Data.Entities;

namespace WeQuestion.Data
{
    public class WeQuestionDbContext : DbContext
    {
        public WeQuestionDbContext(string connectionString)
            : base(connectionString)
        {
            var initializer = new DevelopmentDatabaseInitializer();
            Database.SetInitializer(initializer);
        }

        public IDbSet<ProvisionalUser> ProvisionalUsers { get; set; }
        public IDbSet<SurveyParticipation> SurveyParticipations { get; set; }
        public IDbSet<UsersAnswer> UsersAnswers { get; set; }
        public IDbSet<Survey> Surveys { get; set; }
        public IDbSet<Question> Questions { get; set; }
        public IDbSet<AnswerOption> AnswerOptions { get; set; }


        public class DevelopmentDatabaseInitializer : DropCreateDatabaseAlways<WeQuestionDbContext>
        {
            public override void InitializeDatabase(WeQuestionDbContext context)
            {
                context.Database.CreateIfNotExists();
                // Prevents “Cannot drop database because it is currently in use” error.
                context.Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction, $"ALTER DATABASE {context.Database.Connection.Database} SET SINGLE_USER WITH ROLLBACK IMMEDIATE");
                base.InitializeDatabase(context);
            }

            protected override void Seed(WeQuestionDbContext context)
            {

                var questions = new List<Question>()
                {
                    new Question()
                    {
                        Text =
                            "This is an encryption/decryption key known only to the party or parties that exchange secret messages.",
                        AnswerOptions = new List<AnswerOption>()
                        {
                            new AnswerOption() {Text = "e-signature"},
                            new AnswerOption() {Text = "digital certificate"},
                            new AnswerOption() {Text = "private key", IsCorrect = true},
                            new AnswerOption() {Text = "security token"}
                        }
                    }
                };

                var userParticipations = new List<SurveyParticipation>()
                {
                    new SurveyParticipation()
                    {
                        ProvisionalUser = new ProvisionalUser(),
                        Comment = "Cool",
                        UsersAnswers = new List<UsersAnswer>()
                        {
                           new UsersAnswer()
                           {
                               AnswerOption = questions[0].AnswerOptions.ToList()[0],
                               Question = questions[0],
                           }
                        }
                    }
                };
                userParticipations.ForEach(participation => context.SurveyParticipations.Add(participation));

                new[]
                {
                    new Survey()
                    {
                        AccessToken = null,
                        State = SurvayState.Provisional,
                        Title = "Cryptography",
                        Questions = new List<Question>()
                        {
                            new Question()
                            {
                                Text = "This is an encryption/decryption key known only to the party or parties that exchange secret messages.",
                                AnswerOptions = new List<AnswerOption>()
                                {
                                    new AnswerOption() { Text = "e-signature" },
                                    new AnswerOption() { Text = "digital certificate" },
                                    new AnswerOption() { Text = "private key", IsCorrect = true},
                                    new AnswerOption() { Text = "security token" }
                                }
                            },
                            new Question()
                            {
                                Text = "This was commonly used in cryptography during World War II. ",
                                AnswerOptions = new List<AnswerOption>()
                                {
                                    new AnswerOption() { Text = "tunneling" },
                                    new AnswerOption() { Text = "personalization" },
                                    new AnswerOption() { Text = "van Eck phreaking " },
                                    new AnswerOption() { Text = "one-time pad", IsCorrect = true }
                                }
                            }
                        }
                    },
                    new Survey()
                    {
                        AccessToken = "GlassBird",
                        State = SurvayState.Open,
                        Title = "Test poll #2",
                        ClosingTimestamp = DateTimeOffset.UtcNow.AddMinutes(15),
                        DurationInMinutes = 15,
                        Questions = questions,
                    },
                    new Survey()
                    {
                        AccessToken = "WoodSwitch",
                        State = SurvayState.Closed,
                        DurationInMinutes = 15,
                        Title = "Test poll #3"
                    }
                }.ToList().ForEach(newPoll => context.Surveys.Add(newPoll));

                context.SaveChanges();
            }
        }
    }
}
