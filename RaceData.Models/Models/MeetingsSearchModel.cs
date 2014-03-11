using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using RaceData.Dal.DTO;
using RaceData.Dal.POCO;

namespace RaceData.Web.Models
{
    public class MeetingsSearchModel
    {
        [Required(ErrorMessage = "Please select Country.")]
        public string Country { get; set; }
        [Required(ErrorMessage = "Please select Racecourse.")]
        public string Racecourse { get; set; }
        [Display(Name="Start")]
        public DateTime StartDate { get; set; }
        [Display(Name = "End")]
        public DateTime EndDate { get; set; }
        public List<DtoMeeting> SearchResult { get; set; }
        public bool? IsCreateNew { get; set; }
      
    }
}