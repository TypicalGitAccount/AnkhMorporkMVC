using AnkhMorporkMVC.GameLogic.PredefinedData;

namespace AnkhMorporkMVC.ViewModels
{
    public class IOViewModel
    {
        public string output { get; set; }
        public string input { get; set; }   
        public UserOption EventAnswer { get; set; }
        public string ImagePath { get; set; }

        public IOViewModel(string output = null, string input = null, string imagePath = null)
        {
            this.output = output;
            this.input = input;
            ImagePath = imagePath;

        }

        public IOViewModel(UserOption eventAnswer, string output = null, string input = null, string imagePath = null)
        {
            EventAnswer = eventAnswer;
            this.output = output;
            this.input = input;
            ImagePath=imagePath;
        }

        public IOViewModel() { }
    }
}
