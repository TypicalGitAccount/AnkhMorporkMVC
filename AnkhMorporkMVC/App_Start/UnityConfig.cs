using AnkhMorporkMVC.Controllers;
using AnkhMorporkMVC.GameLogic.GameTools;
using AnkhMorporkMVC.Repositories;
using AnkhMorporkMVC.Services;
using System.Web.Mvc;
using Unity;
using Unity.Injection;
using Unity.Mvc5;

namespace AnkhMorporkMVC
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            container.RegisterType<IGameEventService, GameEventService>();
            container.RegisterType<IAssasinEventService, AssasinEventService>();
            container.RegisterType<IGameEntitiesRepository, GameEntitiesRepository>();
            container.RegisterType <IUserRepository, UserRepository>();
            container.RegisterType <IGameController, GameController>();
            container.RegisterType<AccountController>(new InjectionConstructor());
            container.RegisterType<RolesAdminController>(new InjectionConstructor());
            container.RegisterType<ManageController>(new InjectionConstructor());
            container.RegisterType<UsersAdminController>(new InjectionConstructor());
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}