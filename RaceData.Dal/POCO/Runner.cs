using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLinq;

namespace RaceData.Dal.POCO
{
    [SQLinqTable("Runner")]
    public class Runner
    {

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "")]
        public Int32 Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "")]
        public Int32? RaceId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "")]
        public Int16? HorseNumber { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "")]
        public String Place { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "")]
        public Int16? Barrier { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "")]
        public Int32? HorseId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "")]
        public Int32? JockeyId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "")]
        public Int32? TrainerId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "")]
        public Double? AUS_HcpWt { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "")]
        public Double? HK_ActualWtLbs { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "")]
        public Double? HK_DeclaredHorseWtLbs { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "")]
        public Int16? AUS_HcpRatingAtJump { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "")]
        public Int16? HK_Rating { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "")]
        public Double? AUS_BM { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "")]
        public String HK_LBW { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "")]
        public Double? HK_FinishTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "")]
        public Decimal? AUS_SPW { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "")]
        public Decimal? AUS_SPP { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "")]
        public Decimal? HK_WinOdds { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "")]
        public Int16? RP2000 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "")]
        public Int16? RP1600 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "")]
        public Int16? RP1200 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "")]
        public Int16? RP800 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "")]
        public Int16? RP400 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "")]
        public Int16? AUS_RP200 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "")]
        public Int32? GearId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "")]
        public Double? Z_AUS_FinishTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "")]
        public Boolean? Z_newTrainerSinceLastStart { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "")]
        public Int16? Z_WinOddsRank { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "")]
        public Int16? Z_BPAdvFactor { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "")]
        public Boolean? isScratched { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "")]
        public Double? CarriedWt { get; set; }

    }
}
