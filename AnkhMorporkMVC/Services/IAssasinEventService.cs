using AnkhMorporkMVC.GameLogic.PredefinedData;

namespace AnkhMorporkMVC.Services
{
    public interface IAssasinEventService : IGameEventService
    {
        bool ValidateReward(string rewardInput);
        string ProcessAssasinReward(string rewardInput, UserOption eventAnswer);
    }
}
