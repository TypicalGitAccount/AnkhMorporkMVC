using AnkhMorporkMVC.Services;

namespace AnkhMorporkMVC.Controllers
{
    public class ThieveEventController : GameEventController
    {
        public ThieveEventController(ThieveEventService service) : base(service) { }
    }
}