using AnkhMorpork.GameLogic.Events;
using System.ComponentModel.DataAnnotations;

namespace AnkhMorporkMVC.Models
{
    public class ValidateAssasinReward : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (!AssasinEvent.ValidRewardInput((string)value))
                return new ValidationResult("Please, enter a number!");

            return ValidationResult.Success;
        }
    }
}