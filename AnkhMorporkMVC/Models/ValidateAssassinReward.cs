using AnkhMorpork.GameLogic.Events;
using System.ComponentModel.DataAnnotations;

namespace AnkhMorporkMVC.Models
{
    public class ValidateAssassinReward : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        => AssassinEvent.ValidRewardInput((string)value) == true ? ValidationResult.Success :
            new ValidationResult("Please, enter a number between 0 and 50(no commas, floating point only)!");
    }
}