using System;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using WeQuestion.Data;
using WeQuestion.Web.Controllers;

namespace WeQuestion.Web.App_Start
{
    public static class AutofacConfig
    {
        public static IContainer RegisterDependencies()
        {
            var builder = new ContainerBuilder();
            var dataAccess = AppDomain.CurrentDomain.GetAssemblies();

            builder.RegisterAssemblyTypes(dataAccess)
               .Where(t => t.Name.Contains("Query"))
               .AsImplementedInterfaces()
               .InstancePerRequest();

            builder.RegisterAssemblyTypes(dataAccess)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces()
                .InstancePerRequest();

            builder.RegisterAssemblyTypes(dataAccess)
                .Where(t => t.Name.EndsWith("Command"))
                .AsImplementedInterfaces()
                .InstancePerRequest();


            RegisterDbContext(builder);

            builder.RegisterControllers(dataAccess).InstancePerRequest();
            builder.RegisterApiControllers(dataAccess).InstancePerRequest();

            builder.RegisterType<HomeController>().InstancePerRequest();
            builder.RegisterType<SurveyController>().InstancePerRequest();

            builder.RegisterAssemblyModules(dataAccess);
            builder.RegisterModule<AutofacWebTypesModule>();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            return container;
        }

        private static void RegisterDbContext(ContainerBuilder builder)
        {
            builder.RegisterType<WeQuestionDbContext>()
                .AsImplementedInterfaces()
                .WithParameter("connectionString",
                    @"Data Source=(LocalDB)\MSSQLLocalDB; Initial Catalog=WeQuestion; Integrated Security = True; MultipleActiveResultSets=True")
                .InstancePerRequest();
        }
    }
}