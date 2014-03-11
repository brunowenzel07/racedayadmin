using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RaceData.Dal.DTO;

namespace RaceData.Models.Models
{
    public class JockeyModel
    {
        public int Id { get; set; }
        [MaxLength(2)]
        public string Fullname { get; set; }
        public string Gender { get; set; }
        public bool isApprentice { get; set; }
        public DTOCountryOfOrigin CountryOfOrigin { get; set; }
        public DTOCountryOfRegistration CountryOfRegistration { get; set; }
    }
}
