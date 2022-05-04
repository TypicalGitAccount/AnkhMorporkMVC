using AnkhMorporkMVC.Services;
using AnkhMorporkMVC.ViewModels;
using System.Web.Mvc;

namespace AnkhMorporkMVC.Controllers
{
    [Authorize]
    public class AssasinEventController : GameEventController
    {
        public AssasinEventController(IAssasinEventService _service) : base(_service) { }

        public override ActionResult StartGameEvent()
        {
            
            return View("StartGameEvent", "", new IOViewModel(output: _gameService.StartGameEvent()));
        }

        [HttpPost]
        public override ActionResult Event(IOViewModel model)
        {
            if (model.EventAnswer == GameLogic.PredefinedData.UserOption.No)
                return RedirectToAction("GameOver");
            var newModel = new AssasinRewardViewModel();
            newModel.Input = model.input;
            newModel.EventAnswer = model.EventAnswer;
            return View("AssasinReward", newModel);
        }

        [HttpPost]
        public ActionResult AssasinReward(AssasinRewardViewModel model)
        {
            if (!ModelState.IsValid)
                return View("AssasinReward", model);

            var output = ((IAssasinEventService)_gameService).ProcessAssasinReward(model.Input, model.EventAnswer);
            if (output != null)
            {
                return View("EventResponse", new EventResponseViewModel(output, _gameService.GetUser()));
            }

            return RedirectToAction("GameOver");
        }
    }
}
