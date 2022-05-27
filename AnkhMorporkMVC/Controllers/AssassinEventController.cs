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
            var output = GameService.StartGameEvent();
            var img = GameService.GetEntityImgPath();
            return View(new IOViewModel(output: output, imagePath:img));
        }

        [HttpPost]
        public override ActionResult Event(IOViewModel model)
        {
            return model.EventAnswer == GameLogic.PredefinedData.UserOption.No ?
                GameOver(new GameOverViewModel(GameService.GetUser(), 
                ((AssassinEventService)GameService).ProcessAssassinReward(model.input, model.EventAnswer, out StringBuilder output).ToString(),
                GameService.GetEntityImgPath())) :
                View("AssassinReward", new AssassinRewardViewModel(model.input, model.EventAnswer, GameService.GetEntityImgPath()));
        }

        [HttpPost]
        public ActionResult AssassinReward(AssassinRewardViewModel model)
        {
            if (!ModelState.IsValid)
                return View("AssassinReward", model);

            var imgPath = GameService.GetEntityImgPath();

            return ((AssassinEventService)GameService).ProcessAssassinReward(model.Input, model.EventAnswer, out StringBuilder output) ?
                View("EventResponse", new EventResponseViewModel(output.ToString(), GameService.GetUser(), imgPath)) :
                GameOver(new GameOverViewModel(GameService.GetUser(), output.ToString(), imgPath));
        }
    }
}
