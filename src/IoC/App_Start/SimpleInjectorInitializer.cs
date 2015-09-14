// Isso é feito para fazer um Reflection sobre as camadas que estão utilizando ele.
// É a mesma coisa de fazer o DE/PARA no Global.asax, no Application_Start
[assembly: WebActivator.PostApplicationStartMethod(typeof(NetCoders.MicroErp.IoC.App_Start.SimpleInjectorInitializer), "Initialize")]

namespace NetCoders.MicroErp.IoC.App_Start
{
    using NetCoders.MicroErp.IoC.Containers;
    using SimpleInjector;
    using SimpleInjector.Integration.Web.Mvc;
    using System.Reflection;
    using System.Web.Mvc;

    public static class SimpleInjectorInitializer
    {
        /// <summary>Initialize the container and register it as MVC3 Dependency Resolver.</summary>
        public static void Initialize()
        {
            // Did you know the container can diagnose your configuration? Go to: https://bit.ly/YE8OJj.
            var container = new Container();
            var lifestyle = Lifestyle.Singleton;
            
            // Registrando os conteiners 
            DalContainer.Register(container, lifestyle);
            BllContainer.Register(container, lifestyle);

            //InitializeContainer(container);
            // Esse método abaixo é o que faz tudo acontecer na camada do UI (MVC)
            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }



        //        private static void InitializeContainer(Container container)
        //        {
        //#error Register your services here (remove this line).

        //            // For instance:
        //            // container.Register<IUserRepository, SqlUserRepository>();
        //        }
    }
}