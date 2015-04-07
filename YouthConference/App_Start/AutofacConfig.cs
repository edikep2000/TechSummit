using System.Reflection;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Telerik.OpenAccess;
using YouthConference.Common.ListProducers;
using YouthConference.DataAccess;
using YouthConference.DataAccess.Services;
using YouthConference.Models;

namespace YouthConference.App_Start
{
    public class AutofacConfig
    {
        public static void Configure()
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModelBinders(new[]
                {
                    Assembly.GetExecutingAssembly()
                });
            containerBuilder.RegisterModelBinderProvider();
            containerBuilder.RegisterControllers(new[]
                {
                    Assembly.GetExecutingAssembly()
                });
            containerBuilder.RegisterFilterProvider();
            containerBuilder.RegisterGeneric(typeof(Repository<>)).As(new[]
                {
                    typeof (IRepository<>)
                }).InstancePerHttpRequest(new object[0]);

            containerBuilder.RegisterType<YouthConferenceModels>().As<OpenAccessContext>().InstancePerHttpRequest();
            containerBuilder.RegisterModule(new AutofacWebTypesModule());
            containerBuilder.RegisterControllers(new[]
                {
                    typeof (MvcApplication).Assembly
                });

          
            containerBuilder.RegisterType<RegistrantPersistenceService>().AsSelf();
            containerBuilder.RegisterType<UserProfilePersistenceService>().AsSelf();
          
          

            
            containerBuilder.RegisterType<GenderListProducer>().AsSelf();
           
            var container = containerBuilder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}