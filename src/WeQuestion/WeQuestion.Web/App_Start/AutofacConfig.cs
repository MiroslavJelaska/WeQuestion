using System;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using WeQuestion.Data;
using WeQuestion.Domain.Services;

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
               .AsSelf()
               .InstancePerRequest();

            builder.RegisterAssemblyTypes(dataAccess)
                .Where(t => t.Name.EndsWith("Service"))
                .AsSelf()
                .InstancePerRequest();

            builder.RegisterAssemblyTypes(dataAccess)
                .Where(t => t.Name.EndsWith("Command"))
                .AsSelf()
                .InstancePerRequest();

            builder.RegisterType<AccessTokenGenerator>()
                .AsSelf()
                .SingleInstance();

            RegisterDbContext(builder);

            builder.RegisterControllers(dataAccess).InstancePerRequest();
            builder.RegisterApiControllers(dataAccess).InstancePerRequest();

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
                .AsSelf()
                .WithParameter("connectionString",
                    @"Data Source=(LocalDB)\MSSQLLocalDB; Initial Catalog=WeQuestion; Integrated Security = True; MultipleActiveResultSets=True")
                .InstancePerRequest();
        }
    }
}