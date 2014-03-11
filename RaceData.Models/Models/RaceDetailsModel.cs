using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RaceData.Dal.POCO;

namespace RaceData.Models.Models
{
    public class RaceDetailsModel
    {
        public int Id { get; set; }
        [DisplayName("Race Type Name")]
        public int RaceType { get; set; }
        [DisplayName("Distance")]
        public int Distance { get; set; }
        [DisplayName("Going")]
        public int Going { get; set; }
        [DisplayName("Race Winning Time")]
        public TimeSpan RaceWinningTime { get; set; }
        [DisplayName("Number of Runner")]
        public int NumberOfRunners { get; set; }
        public string  Weather { get; set; }
        public int RaceNumber { get; set; }
        public int MeetingId { get; set; }
        [DisplayName("Race Jump Time")]
        public int RaceJumpTimeHour { get; set; }
        public int RaceJumpTimeMin { get; set; }
        [DisplayName("Race Name")]
        public string RaceName { get; set; }
        [DisplayName("Race Index")]
        public int HK_RaceIndex { get; set; }
        [DisplayName("Is Started")]
        public bool IsStarted { get; set; }
        [DisplayName("Is Done")]
        public bool IsDone { get; set; }
        public List<Runner> Runners { get; set; } 
    }
}
