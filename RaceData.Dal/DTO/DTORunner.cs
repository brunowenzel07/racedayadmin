using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceData.Dal.DTO
{
    public class DTORunner
    {
       
        public Int32 Id { get; set; }
        public Int32? RaceId { get; set; }
        [Display(Name = "Horse Number")]
        public Int16? HorseNumber { get; set; }
        public String Place { get; set; }
        public Int16? Barrier { get; set; }
        [Display(Name = "HcpWt")]
        public Double? AUS_HcpWt { get; set; }
        [Display(Name = "ActualWtLbs")]
        public Double? HK_ActualWtLbs { get; set; }
        [Display(Name = "DeclaredHorseWtLbs")]
        public Double? HK_DeclaredHorseWtLbs { get; set; }
        [Display(Name = "DeclaredHorseWtLbs")]
        public Int16? AUS_HcpRatingAtJump { get; set; }
        [Display(Name = "Rating")]
        public Int16? HK_Rating { get; set; }
        [Display(Name = "BM")]
        public Double? AUS_BM { get; set; }
        [Display(Name="LBM")]
        public String HK_LBW { get; set; }
        [Display(Name = "FinishTime")]
        public Double? HK_FinishTime { get; set; }
        [Display(Name = "SPW")]
        public Decimal? AUS_SPW { get; set; }
        [Display(Name="SPP")]
        public Decimal? AUS_SPP { get; set; }
        [Display(Name = "WinOdds")]
        public Decimal? HK_WinOdds { get; set; }
        public Int16? RP2000 { get; set; }
        public Int16? RP1600 { get; set; }
        public Int16? RP1200 { get; set; }
        public Int16? RP800 { get; set; }
        public Int16? RP400 { get; set; }
        [Display(Name = "RP200")]
        public Int16? AUS_RP200 { get; set; }
        public Int32? GearId { get; set; }
        public Double? Z_AUS_FinishTime { get; set; }
        public Boolean? Z_newTrainerSinceLastStart { get; set; }
        public Int16? Z_WinOddsRank { get; set; }
        public Int16? Z_BPAdvFactor { get; set; }
        public Boolean? isScratched { get; set; }
        public Double? CarriedWt { get; set; }
        public DTOGear Gear { get; set; }
       
        public DTOHorse Horse { get; set; }
        public DTOTrainer Trainer { get; set; }
        public DTOJockey Jockey { get; set; }

    }
}
