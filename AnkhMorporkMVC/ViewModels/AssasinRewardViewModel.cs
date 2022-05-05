using AnkhMorporkMVC.GameLogic.PredefinedData;
using AnkhMorporkMVC.Models;

namespace AnkhMorporkMVC.ViewModels
{
    public class AssasinRewardViewModel
    {
        [ValidateAssasinReward]
        public string Input { get; set; }
        public UserOption EventAnswer { get; set; }
        public string ImagePath { get; set; }

        public AssasinRewardViewModel(string input, UserOption answer, string imagePath) { Input = input; EventAnswer = answer; ImagePath = imagePath; }
        public AssasinRewardViewModel() { }
    }
}