using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLinq;

namespace RaceData.Dal.POCO
{
    [SQLinqTable("Race")]
    public partial class Race
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
        [SQLinqColumn("MeetingId")]
        public Int32? MeetingId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "")]
        [SQLinqColumn("RaceNumber")]
        public Int16? RaceNumber { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "")]
        [SQLinqColumn("RaceName")]
        public String RaceName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "")]
        [SQLinqColumn("RaceTypeId")]
        public Int32? RaceTypeId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "")]
        [SQLinqColumn("DistanceId")]
        public Int32? DistanceId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "")]
        [SQLinqColumn("RaceJumpDateTimeUTC")]
        public DateTime? RaceJumpDateTimeUTC { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "")]
        [SQLinqColumn("HK_RaceIndex")]
        public Int32? HK_RaceIndex { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "")]
        [SQLinqColumn("RaceWinningTime")]
        public TimeSpan RaceWinningTime{ get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "")]
        [SQLinqColumn("RaceGoingId")]
        public Int32? RaceGoingId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "")]
        [SQLinqColumn("isTurf")]
        public Boolean? isTurf { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "")]
        [SQLinqColumn("NumberOfRunners")]
        public Int16? NumberOfRunners { get; set; }

        [Display(Name = "")]
        [SQLinqColumn("isDone")]
        public Boolean? isDone { get; set; }

        [Display(Name = "")]
        [SQLinqColumn("isStarted")]
        public Boolean? isStarted { get; set; }

    }
}
