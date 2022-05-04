using AnkhMorporkMVC.ViewModels;
using AnkhMorporkMVC.Services;
using System.Web.Mvc;

namespace AnkhMorporkMVC.Controllers
{
    [Authorize]
    public class GameEventController : Controller
    {
        protected IGameEventService _gameService;

        public GameEventController(IGameEventService _service)
        {
            _gameService = _service;
        }

        public virtual ActionResult StartGameEvent()
        {
            return View(new IOViewModel(output: _gameService.StartGameEvent()));
        }

        [HttpPost]
        public virtual ActionResult Event(IOViewModel model)
        {
            var output = _gameService.ProcessEvent(model.EventAnswer);
            if (output != null)
                return View("EventResponse", new EventResponseViewModel(output, _gameService.GetUser()));

            return RedirectToAction("GameOver");
        }

        public virtual ActionResult EventResponse(EventResponseViewModel model)
        {
            return View(model);
        }

        public virtual ActionResult GameOver()
        {
            return View(_gameService.GameOver());
        }
    }
}
