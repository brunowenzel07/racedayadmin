using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceData.Models.Models
{
    public class HorseOddModel
    {
        public int Id { get; set; }
        public int RaceId { get; set; }
        [Display(Name = "Race Jump Time")]
        public DateTime? CurrentTime { get; set; }
        [Display(Name = "Horse Number")]
        public int? HorseNumber { get; set; }
        [Display(Name = "Horse Name")]
        public string HorseName { get; set; }
        public int? HorseId { get; set; }
        [Display(Name = "Win Odds")]
        [RegularExpression(@"^\d*\.*\d*$", ErrorMessage = "Must be a Number.")]
        public decimal? WinOdds { get; set; }
        [Display(Name="Place Odds")]
        public decimal? PlaceOdds { get; set; }

    }

}

