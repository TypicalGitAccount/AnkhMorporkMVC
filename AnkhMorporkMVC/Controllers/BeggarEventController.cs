using AnkhMorporkMVC.Services;

namespace AnkhMorporkMVC.Controllers
{
    public class BeggarEventController : GameEventController
    {
        public BeggarEventController(BeggarEventService service) : base(service) { }
    }
}