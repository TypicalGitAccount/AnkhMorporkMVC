using System;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;

namespace AnkhMorporkMVC.Controllers
{
    public class HomeController : Controller
    { 
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GenerateGameEvent()
        {
            var rand = new Random();
            var eventControllers = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.IsSubclassOf(typeof(GameEventController))).Select(t => t.Name).ToList();
            eventControllers.Add(typeof(GameEventController).Name);
            var typeName = eventControllers[rand.Next(0, eventControllers.Count())].Replace("Controller", "");
            return RedirectToAction("StartGameEvent", typeName);
        }
    }
}
