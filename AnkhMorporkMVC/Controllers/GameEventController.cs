using AnkhMorporkMVC.ViewModels;
using AnkhMorporkMVC.Services;
using System.Web.Mvc;
using System.Text;

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
            var output = _gameService.StartGameEvent();
            return View(new IOViewModel(output: output, imagePath:_gameService.GetEntityImgPath()));
        }

        [HttpPost]
        public virtual ActionResult Event(IOViewModel model)
        {
            StringBuilder output;
            var imgPath = _gameService.GetEntityImgPath();
            if (_gameService.ProcessEvent(model.EventAnswer, out output))
                return EventResponse(new EventResponseViewModel(output.ToString(), _gameService.GetUser(), imgPath));

            return GameOver(new GameOverViewModel(_gameService.GetUser(), output.ToString(), imgPath));
        }

        public virtual ActionResult EventResponse(EventResponseViewModel model)
        {
            return View("EventResponse", model);
        }

        public virtual ActionResult DbError()
        {
            return View();
        }

        public virtual ActionResult GameOver(GameOverViewModel model)
        {
            _gameService.GameOver();
            return View("GameOver", model);
        }
    }
}
