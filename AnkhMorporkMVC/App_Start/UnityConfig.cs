using AnkhMorporkMVC.Repositories;
using AnkhMorporkMVC.Services;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace AnkhMorporkMVC
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            container.RegisterType<AssassinEventService>();
            container.RegisterType<PubEventService>();
            container.RegisterType<BeggarEventService>();
            container.RegisterType<ThieveEventService>();
            container.RegisterType<FoolEventService>();
            container.RegisterType<IGameEntitiesRepository, GameEntitiesRepository>();
            container.RegisterType<IUserRepository, UserRepository>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}