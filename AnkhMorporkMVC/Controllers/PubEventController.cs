using AnkhMorporkMVC.Services;

namespace AnkhMorporkMVC.Controllers
{
    public class PubEventController : GameEventController
    {
        public PubEventController(PubEventService service) : base(service) { }
    }
}