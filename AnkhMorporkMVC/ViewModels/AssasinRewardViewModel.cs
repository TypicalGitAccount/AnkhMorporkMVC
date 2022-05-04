using AnkhMorporkMVC.GameLogic.PredefinedData;
using AnkhMorporkMVC.Models;

namespace AnkhMorporkMVC.ViewModels
{
    public class AssasinRewardViewModel
    {
        [ValidateAssasinReward]
        public string Input { get; set; }
        public UserOption EventAnswer { get; set; }
    }
}