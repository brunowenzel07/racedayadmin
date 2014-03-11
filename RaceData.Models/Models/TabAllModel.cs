using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RaceData.Dal.POCO;

namespace RaceData.Models.Models
{
    public class TabAllModel
    {
            [Display(Name = "Race 1")]
            public bool Race1 { get; set; }
            [Display(Name = "Race 2")]
            public bool Race2 { get; set; }
            [Display(Name = "Race 3")]
            public bool Race3 { get; set; }
            [Display(Name = "Race 4")]
            public bool Race4 { get; set; }
            [Display(Name = "Race 5")]
            public bool Race5 { get; set; }
            [Display(Name = "Race 6")]
            public bool Race6 { get; set; }
            [Display(Name = "Race 7")]
            public bool Race7 { get; set; }
            [Display(Name = "Race 8")]
            public bool Race8 { get; set; }
            [Display(Name = "Race 9")]
            public bool Race9 { get; set; }
            [Display(Name = "Race 10")]
            public bool Race10 { get; set; }
            [Display(Name = "Race 11")]
            public bool Race11 { get; set; }
            [Display(Name = "Race 12")]
            public bool Race12 { get; set; }

        public TabAllModel(bool isSelected)
        {
                Race1 = Race2 = Race3 = 
                Race4 = Race5 = Race6 = 
                Race7 = Race8 = Race9 = 
                Race10 = Race11 = Race12 = isSelected;
        }

        public TabAllModel()
        {
        }
    }
}
