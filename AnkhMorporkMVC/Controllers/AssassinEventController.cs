using AnkhMorporkMVC.Services;
using AnkhMorporkMVC.ViewModels;
using System.Text;
using System.Web.Mvc;

namespace AnkhMorporkMVC.Controllers
{
    public class AssassinEventController : GameEventController
    {
        public AssassinEventController(AssassinEventService service) : base(service) { }

        public override ActionResult StartGameEvent()
        {
            var output = _gameService.StartGameEvent();
            var img = _gameService.GetEntityImgPath();
            return View(new IOViewModel(output: output, imagePath:img));
        }

        [HttpPost]
        public override ActionResult Event(IOViewModel model)
        {
            return model.EventAnswer == GameLogic.PredefinedData.UserOption.No ?
                GameOver(new GameOverViewModel(_gameService.GetUser(), 
                ((AssassinEventService)_gameService).ProcessAssassinReward(model.input, model.EventAnswer, out StringBuilder output).ToString(),
                _gameService.GetEntityImgPath())) :
                View("AssassinReward", new AssassinRewardViewModel(model.input, model.EventAnswer, _gameService.GetEntityImgPath()));
        }

        [HttpPost]
        public ActionResult AssassinReward(AssassinRewardViewModel model)
        {
            if (!ModelState.IsValid)
                return View("AssassinReward", model);

            StringBuilder output;
            var imgPath = _gameService.GetEntityImgPath();
            if (((AssassinEventService)_gameService).ProcessAssassinReward(model.Input, model.EventAnswer, out output))
            {
                return View("EventResponse", new EventResponseViewModel(output.ToString(), _gameService.GetUser(), imgPath));
            }

            return GameOver(new GameOverViewModel(_gameService.GetUser(), output.ToString(), imgPath));
        }
    }
}
