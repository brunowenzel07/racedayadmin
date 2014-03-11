using System;
using System.ComponentModel.DataAnnotations;
using RaceData.Dal.POCO;

namespace RaceData.Dal.DTO
{
    public class DTORaceType
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name required.")]
        public String Name { get; set; }
        [Display(Name = "Country")]
        [Required(ErrorMessage = "Country required.")]
        public DTOCountry Country { get; set; }
        [Display(Name = "Is Group")]
        public bool IsGroup { get; set; }
    }

    public class DTORaceType2
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public bool IsGroup { get; set; }



    }

}
