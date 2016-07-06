using System.Data.Entity;
using System.Linq;
using WeQuestion.Data.Entities;

namespace WeQuestion.Data
{
    public class WeQuestionDbContext : DbContext
    {
        public WeQuestionDbContext()
            : base(@"Data Source=(LocalDB)\MSSQLLocalDB; Initial Catalog=WeQuestion; Integrated Security = True; MultipleActiveResultSets=True")
        {
            var initializer = new DevelopmentDatabaseInitializer();
            Database.SetInitializer(initializer);
        }

        public IDbSet<ProvisionalUser> ProvisionalUsers { get; set; }
        public IDbSet<SurveyParticipation> PollParticipations { get; set; }
        public IDbSet<UsersAnswer> UsersAnswers { get; set; }
        public IDbSet<Survey> Polls { get; set; }
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
                new[]
                {
                    new Survey()
                    {
                        AccessToken = "CarTreePc",
                        State = SurvayState.Provisional,
                        Title = "Test poll"
                    },
                    new Survey()
                    {
                        AccessToken = "GlassBirdSwitch",
                        State = SurvayState.Open,
                        Title = "Test poll #2"
                    },
                    new Survey()
                    {
                        AccessToken = "GlassBirdSwitch",
                        State = SurvayState.Closed,
                        Title = "Test poll #3"
                    }
                }.ToList().ForEach(newPoll => context.Polls.Add(newPoll));

                context.SaveChanges();
            }
        }
    }
}
