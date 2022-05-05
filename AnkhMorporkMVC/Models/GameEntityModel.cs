using AnkhMorporkMVC.GameLogic.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace AnkhMorporkMVC.Models
{
    public class GameEntityModel 
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int InteractionCostPennies { get; set; }

        public string ImagePath { get; set; }

        public virtual GameEntity ToObject()
        {
            throw new NotImplementedException();
        }
    }
}
