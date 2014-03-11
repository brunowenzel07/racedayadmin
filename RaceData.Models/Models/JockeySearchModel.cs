using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RaceData.Dal.POCO;

namespace RaceData.Models.Models
{
    public class JockeySearchModel
    {
        [Required(ErrorMessage = "Country is required")]
        public int? CountryId { get; set; }
        public List<vwvJockey> JockeyModels { get; set; }

    }
}
