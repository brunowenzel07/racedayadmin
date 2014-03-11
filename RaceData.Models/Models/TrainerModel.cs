using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RaceData.Dal.DTO;

namespace RaceData.Models.Models
{
    public class TrainerModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public DTORaceCourse HomeTrack { get; set; }
    }
}
