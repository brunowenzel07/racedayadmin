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
    public enum MeetingType
    {
        nigth,
        day
    }

    [SQLinqTable("Meeting")]
    public class Meeting
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
        [SQLinqColumn("CountryId")]
        public Int32? CountryId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "")]
        [SQLinqColumn("MeetingDate")]
        public DateTime MeetingDate { get; set; }

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
        [SQLinqColumn("WeatherId")]
        public Int32? WeatherId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "")]
        [SQLinqColumn("DefaultGoingId")]
        public Int32? DefaultGoingId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "")]
        [SQLinqColumn("NumberOfRaces")]
        public Int32? NumberOfRaces { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "")]
        [SQLinqColumn("HK_isNightMeet")]
        public Boolean? HK_isNightMeet { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "")]
        [SQLinqColumn("CourseVariantId")]
        public Int32? CourseVariantId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "")]
        [SQLinqColumn("Z_MeetingCode")]
        public String Z_MeetingCode { get; set; }
    }
}