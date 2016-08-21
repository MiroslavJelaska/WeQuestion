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

        public IDbSet<User> Users { get; set; }
        public IDbSet<ProvisionalUser> ProvisionalUsers { get; set; }
        public IDbSet<SurveyParticipation> SurveyParticipations { get; set; }
        public IDbSet<UsersAnswer> UsersAnswers { get; set; }
        public IDbSet<Survey> Surveys { get; set; }
        public IDbSet<Question> Questions { get; set; }
        public IDbSet<AnswerOption> AnswerOptions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Survey>()
                .HasMany(survey => survey.SurveyParticipations)
                .WithRequired(surveyParticipation => surveyParticipation.Survey);
        }

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
                var user = new User()
                {
                    Email = "mcagalj@fesb.hr",
                    Password = "$2a$12$lU5HHjOkcHvR7BobZDyIKe7uKExeGxMDzZZEEh6YsASw7Bmy/pcDK", //fesb
                    Surveys = new List<Survey>()
                };

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
                                },
                                Index = 0
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
                                },
                                Index = 1
                            }
                        }
                    },
                    new Survey()
                    {
                        AccessToken = "GlassBird",
                        State = SurvayState.Published,
                        Title = "Test poll #2",
                        ClosingTimestamp = DateTimeOffset.UtcNow.AddMinutes(15),
                        DurationInMinutes = 15,
                        Questions = new List<Question>()
                        {
                            new Question()
                            {
                                Text = "This is an encryption/decryption key known only to the party or parties that exchange secret messages.",
                                AnswerOptions = new List<AnswerOption>()
                                {
                                    new AnswerOption() {Text = "e-signature"},
                                    new AnswerOption() {Text = "digital certificate"},
                                    new AnswerOption() {Text = "private key", IsCorrect = true},
                                    new AnswerOption() {Text = "security token"}
                                }
                            },
                            new Question()
                            {
                                Text = "Today, many Internet businesses and users take advantage of cryptography based on this approach.",
                                AnswerOptions = new List<AnswerOption>()
                                {
                                    new AnswerOption() {Text = "public key infrastructure", IsCorrect = true},
                                    new AnswerOption() {Text = "output feedback"},
                                    new AnswerOption() {Text = "Encrypting File System " },
                                    new AnswerOption() {Text = "single signon"}
                                }
                            },
                            new Question()
                            {
                                Text = "This is the name for the issuer of a PKI certificate.",
                                AnswerOptions = new List<AnswerOption>()
                                {
                                    new AnswerOption() {Text = "man in the middle", IsCorrect = true},
                                    new AnswerOption() {Text = "certificate authority" },
                                    new AnswerOption() {Text = "Resource Access Control Facility" },
                                    new AnswerOption() {Text = "script kiddy"}
                                }
                            },
                            new Question()
                            {
                                Text = "Developed by Philip R. Zimmermann, this is the most widely used privacy-ensuring program by individuals and is also used by many corporations.",
                                AnswerOptions = new List<AnswerOption>()
                                {
                                    new AnswerOption() {Text = "DSS" },
                                    new AnswerOption() {Text = "OCSP" },
                                    new AnswerOption() {Text = "Secure HTTP" },
                                    new AnswerOption() {Text = "Pretty Good Privacy", IsCorrect = true}
                                }
                            }
                        }
                    },
                    new Survey()
                    {
                        AccessToken = "WoodSwitch",
                        State = SurvayState.Published,
                        DurationInMinutes = 15,
                        Title = "Test poll #3"
                    }
                }.ToList().ForEach(newPoll => user.Surveys.Add(newPoll));

                context.Users.Add(user);

                context.SaveChanges();
            }
        }
    }
}
