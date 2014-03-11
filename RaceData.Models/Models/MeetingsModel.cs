using System;
using System.ComponentModel.DataAnnotations;

namespace RaceData.Web.Models
{
    public class MeetingsModel   
    {
        public int CountryId { get; set; }
        public int RacecourseId { get; set; }
        public string CountryCode { get; set; }
        public string Racecourse { get; set; }
        public string Weather { get; set; }
        [Required(ErrorMessage = "Please select Going.")]
        public string Going { get; set; }
        public string MeetingType { get; set; }
        [Range(0, 12, ErrorMessage = "Race Number must >=0 and <=12")]
        public int RaceNumber { get; set; }
        [Required(ErrorMessage = "Please select Meeting Date.")]
        public DateTime MeetingDate { get; set; }
    }
}