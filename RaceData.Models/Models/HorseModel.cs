using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RaceData.Dal.DTO;

namespace RaceData.Models.Models
{
    public class HorseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DTOCountryOfOrigin CountryOfOrigin { get; set; }
        public string HK_ChineseName { get; set; }
        public string HK_BrandNumber { get; set; }
        public bool SG_hasBled { get; set; }
        public DTOSex Sex { get; set; }
        public DTOColor CoatColor { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string SireName { get; set; }
        public string DamName { get; set; }
        public bool IsActive { get; set; }
        public short Z_MaxHcpRating { get; set; }
        public short Z_CurrentHcpRating { get; set; }
        public short Z_StartSeasonHcpRating { get; set; }
        public DTOCountry CountryOfRegistration { get; set; }
        
    }
}
