using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RaceData.Dal.POCO;

namespace RaceData.Models.Models
{
    public class TrainerSearchModel
    {
        public int CountryId { get; set; }
        public List<Trainer> Trainers { get; set; }
    }
}
