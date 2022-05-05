using AnkhMorporkMVC.Services;
using AnkhMorporkMVC.ViewModels;
using System.Text;
using System.Web.Mvc;

namespace AnkhMorporkMVC.Controllers
{
    public class AssasinEventController : GameEventController
    {
        public AssasinEventController(AssasinEventService _service) : base(_service) { }

        public override ActionResult StartGameEvent()
        {
            var output = _gameService.StartGameEvent();
            var img = _gameService.GetEntityImgPath();
            return View(new IOViewModel(output: output, imagePath:img));
        }

        [HttpPost]
        public override ActionResult Event(IOViewModel model)
        {
            if (model.EventAnswer == GameLogic.PredefinedData.UserOption.No)
            {
                StringBuilder output;
                ((AssasinEventService)_gameService).ProcessAssasinReward(model.input, model.EventAnswer, out output);
                return GameOver(new GameOverViewModel(_gameService.GetUser(), output.ToString(), _gameService.GetEntityImgPath()));
            }
            var newModel = new AssasinRewardViewModel(model.input, model.EventAnswer, _gameService.GetEntityImgPath());
            return View("AssasinReward", newModel);
        }

        [HttpPost]
        public ActionResult AssasinReward(AssasinRewardViewModel model)
        {
            if (!ModelState.IsValid)
                return View("AssasinReward", model);

            StringBuilder output;
            var imgPath = _gameService.GetEntityImgPath();
            if (((AssasinEventService)_gameService).ProcessAssasinReward(model.Input, model.EventAnswer, out output))
            {
                return View("EventResponse", new EventResponseViewModel(output.ToString(), _gameService.GetUser(), imgPath));
            }

            return GameOver(new GameOverViewModel(_gameService.GetUser(), output.ToString(), imgPath));
        }
    }
}
