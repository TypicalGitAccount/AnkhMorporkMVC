namespace AnkhMorporkMVC.GameLogic.States
{
    public class PubState : GameEntityState
    {
        public bool IsOpen { get; set; }
        public PubState(bool IsOpen) : base(PredefinedData.Pub.Name, PredefinedData.Pub.InteractionCostPennies) { this.IsOpen = IsOpen; }

        public PubState(string name, int reward, bool isOpen) : base(name, reward) { IsOpen = isOpen; }
    }
}
