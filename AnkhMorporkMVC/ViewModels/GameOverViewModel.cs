using AnkhMorporkMVC.GameLogic.GameTools;

namespace AnkhMorporkMVC.ViewModels
{
    public class GameOverViewModel
    {
        public User User { get; set; }
        public string Output { get; set; }
        public string ImagePath { get; set; }
        public GameOverViewModel(User user, string output, string imagePath) { User = user; Output = output; ImagePath = imagePath; }

        public GameOverViewModel() { }
    }
}