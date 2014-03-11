using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceData.Dal.DTO
{
    public class DtoMeeting
    {
        public Int32 Id { get; set; }
        public Int32? CountryId { get; set; }
        public DateTime MeetingDate { get; set; }
        public Int32? RaceCourseId { get; set; }
        public Int32? WeatherId { get; set; }
        public Int32? DefaultGoingId { get; set; }
        public Int32? NumberOfRaces { get; set; }
        public Boolean? HK_isNightMeet { get; set; }
        public Int32? CourseVariantId { get; set; }
        public String Z_MeetingCode { get; set; }
        public string CountryCode { get; set; }
        public string RacecourseName { get; set; }
    }
}
