using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RaceData.Dal.Core;
using SQLinq;

namespace RaceData.Dal.POCO
{
    [SQLinqTable("Weather")]
    public class Weather 
    {

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "")]
        [SQLinqColumn("Id")]
        public Int32 Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "")]
        [SQLinqColumn("Name")]
        public String Name { get; set; }

    }
}
