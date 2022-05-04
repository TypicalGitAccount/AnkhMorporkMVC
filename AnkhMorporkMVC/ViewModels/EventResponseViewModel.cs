using AnkhMorporkMVC.GameLogic.GameTools;

namespace AnkhMorporkMVC.ViewModels
{
    public class EventResponseViewModel
    {
        public string Output { get; set; }
        public User User { get; set; }

        public EventResponseViewModel(string output, User user) { Output = output; User = user; }
    }
}