[assembly: WebActivator.PostApplicationStartMethod(typeof(OuiFund.App_Start.SimpleInjectorInitializer), "Initialize")]

namespace OuiFund.App_Start
{
    using System.Reflection;
    using System.Web.Mvc;

    using SimpleInjector;
    using SimpleInjector.Integration.Web;
    using SimpleInjector.Integration.Web.Mvc;
    using Domain.Repositories;
    using Data;
    using System.Data.Entity;
    using OuiFund.Data.Repository;
    using OuiFund.Services.IServices;
    using OuiFund.Services.Services;

    public static class SimpleInjectorInitializer
    {
        /// <summary>Initialize the container and register it as MVC3 Dependency Resolver.</summary>
        public static void Initialize()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();
            
            InitializeContainer(container);

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            
            container.Verify();
            
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
     
        private static void InitializeContainer(Container container)
        {
            container.Register<OuiFundContext, OuiFundContext>(Lifestyle.Scoped);
            container.Register<IUserRepository, UserRepository>(Lifestyle.Scoped);
            container.Register<IUserService, UserService>(Lifestyle.Scoped);

            container.Register<IAdherentRepository, AdherentRepository>(Lifestyle.Scoped);
            container.Register<IAdherentService, AdherentService>(Lifestyle.Scoped);

            container.Register<IAnalyseRepository, AnalyseRepository>(Lifestyle.Scoped);
            container.Register<IAnalyseService, AnalyseService>(Lifestyle.Scoped);

            container.Register<IClientRepository, ClientRepository>(Lifestyle.Scoped);

            container.Register<IDossierRepository, DossierRepository>(Lifestyle.Scoped);
            container.Register<IDossierService, DossierService>(Lifestyle.Scoped);
            container.Register<IStartupRepository, StartupRepository>(Lifestyle.Scoped);
            container.Register<IStartupService, StartupService>(Lifestyle.Scoped);

            container.Register<IQuestionRepository, QuestionRepository>(Lifestyle.Scoped);
            container.Register<IQuestionService, QuestionService>(Lifestyle.Scoped);
            container.Register<ICategorieRepository, CategorieRepository>(Lifestyle.Scoped);
            container.Register<ICategorieService, CategorieService>(Lifestyle.Scoped);
            container.Register<IReponseRepository, ReponseRepository>(Lifestyle.Scoped);
            container.Register<IReponseService, ReponseService>(Lifestyle.Scoped);

            container.Register<IEncryptionService, EncryptionService>(Lifestyle.Scoped);

        }
    }
}