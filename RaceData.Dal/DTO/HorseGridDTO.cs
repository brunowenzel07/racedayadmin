using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLinq;

namespace RaceData.Dal.DTO
{
    public class HorseGridDTO
    {
        
        public Int32 Id { get; set; }

        [Display(Name = "Name")]
        [SQLinqColumn("Name")]
        public String Name { get; set; }

        [Display(Name = "PreviousName")]
        [SQLinqColumn("PreviousName")]
        public String PreviousName { get; set; }

        [Display(Name = "Brand Number")]
        [SQLinqColumn("HK_BrandNumber")]
        public String HK_BrandNumber { get; set; }

        [Display(Name = "Date Of Birth")]
        [SQLinqColumn("DateOfBirth")]
        public DateTime? DateOfBirth { get; set; }


    }
}
