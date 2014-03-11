using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RaceData.Dal.POCO;

namespace RaceData.Models.Models
{
    public class MeetingsDetailsModel
    {
        public int MeetingId            { get; set; }
        public string CountryCode       { get; set; }
        public string RaceCourseCode    { get; set; }
        public string Date              { get; set; }
        public string WeatherName       { get; set; }
        public string GoingName         { get; set; }
        public string DayNight          { get; set; }
        public string CourseVariantName { get; set; }
        public int? NumberOfRaces       { get; set; }
        public List<Race> Races         { get; set; }
 
    }
}
