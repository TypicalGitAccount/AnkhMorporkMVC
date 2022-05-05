using AnkhMorporkMVC.Services;

namespace AnkhMorporkMVC.Controllers
{
    public class FoolEventController : GameEventController
    {
        public FoolEventController(FoolEventService service) : base(service) { }
    }
}