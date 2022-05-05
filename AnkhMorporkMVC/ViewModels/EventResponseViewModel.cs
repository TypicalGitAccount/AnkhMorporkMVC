using AnkhMorporkMVC.GameLogic.GameTools;

namespace AnkhMorporkMVC.ViewModels
{
    public class EventResponseViewModel
    {
        public string Output { get; set; }
        public User User { get; set; }
        public string ImagePath { get; set; }
        public EventResponseViewModel(string output, User user, string imagePath) { Output = output; User = user; ImagePath = imagePath; }
    }
}