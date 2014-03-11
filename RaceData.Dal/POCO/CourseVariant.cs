using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLinq;

namespace RaceData.Dal.POCO
{
    [SQLinqTable("CourseVariant")]
    public partial class CourseVariant 
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
        [SQLinqColumn("Code")]
        public String Code { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "")]
        [SQLinqColumn("Name")]
        public String Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "")]
        [SQLinqColumn("RaceCourseId")]
        public Int32? RaceCourseId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "")]
        [SQLinqColumn("LengthHomeStraightm")]
        public Int16? LengthHomeStraightm { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "")]
        [SQLinqColumn("Circumferencem")]
        public Int16? Circumferencem { get; set; }

    }
}
