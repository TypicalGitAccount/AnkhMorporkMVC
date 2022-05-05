using AnkhMorporkMVC.GameLogic.PredefinedData;
using System.Text;

namespace AnkhMorporkMVC.Services
{
    public interface IAssasinEventService : IGameEventService
    {
        bool ValidateReward(string rewardInput);
        bool ProcessAssasinReward(string rewardInput, UserOption eventAnswer, out StringBuilder output);
    }
}
