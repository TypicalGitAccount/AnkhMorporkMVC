namespace AnkhMorporkMVC.GameLogic.States
{
    public class PubState : GameEntityState
    {
        public bool IsOpen { get; set; }
        public PubState(bool isOpen) : base(PredefinedData.Pub.Name, PredefinedData.Pub.InteractionCostPennies) { IsOpen = isOpen; }

        public PubState(string name, int reward, bool isOpen) : base(name, reward) { IsOpen = isOpen; }
    }
}
