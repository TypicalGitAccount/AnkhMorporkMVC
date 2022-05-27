using AnkhMorporkMVC.ViewModels;
using AnkhMorporkMVC.Services;
using System.Web.Mvc;
using System.Text;

namespace AnkhMorporkMVC.Controllers
{
    public class GameEventController : Controller
    {
        protected GameEventService GameService;

        public GameEventController(GameEventService service)
        {
            GameService = service;
        }

        public virtual ActionResult StartGameEvent()
        {
            var output = GameService.StartGameEvent();
            return View(new IOViewModel(output, GameService.GetEntityImgPath()));
        }

        [HttpPost]
        public virtual ActionResult Event(IOViewModel model)
        {
            var imgPath = GameService.GetEntityImgPath();

            return GameService.ProcessEvent(model.EventAnswer, out StringBuilder output) == true ?
                EventResponse(new EventResponseViewModel(output.ToString(), GameService.GetUser(), imgPath))
                : GameOver(new GameOverViewModel(GameService.GetUser(), output.ToString(), imgPath));
        }

        public virtual ActionResult EventResponse(EventResponseViewModel model)
        {
            return View("EventResponse", model);
        }

        public virtual ActionResult GameOver(GameOverViewModel model)
        {
            GameService.GameOver();
            return View("GameOver", model);
        }
    }
}
