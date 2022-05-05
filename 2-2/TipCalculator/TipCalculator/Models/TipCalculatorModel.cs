using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TipCalculator.Models
{
    public class TipCalculatorModel
    {
        [Required(ErrorMessage = "Please enter a meal cost.")]
        [Range(1, 1000000, ErrorMessage = "Meal cost must be between 1 and 1000000")]
        public decimal? mealCost { get; set; }
        public decimal? CalculateTipValue(decimal precent)
        {
            precent = (precent / 100);
            return (mealCost * precent);
        }
    }
}
