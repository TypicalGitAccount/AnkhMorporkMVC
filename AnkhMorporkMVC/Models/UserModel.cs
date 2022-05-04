using AnkhMorporkMVC.GameLogic.GameTools;
using System.ComponentModel.DataAnnotations;

namespace AnkhMorporkMVC.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        [Required]
        public int BalancePennies { get; set; }
        [Required]
        public int Moves { get; set; }
        [Required]
        public byte Beers { get; set; }

        public UserModel() { }

        public UserModel(User user)
        {
            BalancePennies = user.BalancePennies;
            Moves = user.Moves;
            Beers = user.Beers;
        }

        public User ToObject()
        {
            var user = new User();
            user.BalancePennies = BalancePennies;
            user.Moves = Moves;
            user.Beers = Beers;
            return user;
        }
    }
}