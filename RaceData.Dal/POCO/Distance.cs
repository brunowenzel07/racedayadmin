using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLinq;

namespace RaceData.Dal.POCO
{
    [SQLinqTable("Distance")]
    public partial class Distance
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
        public Int16 Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "")]
        [SQLinqColumn("RaceCourseID")]
        public Int32? RaceCourseID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "")]
        [SQLinqColumn("JP_Distance_Category")]
        public String JP_Distance_Category { get; set; }

    }
}
