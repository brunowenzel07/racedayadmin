using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLinq;

namespace RaceData.Dal.POCO
{
    [SQLinqTable("Horse")]
    public class Horse : IComparable<Horse>
    {

        /// <summary>
        /// 
        /// </summary>
        [SQLinqColumn("Id")]
        public Int32 Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "")]
        [SQLinqColumn("GUID")]
        public System.Guid? GUID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "")]
        [SQLinqColumn("HorseCode")]
        public String HorseCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "")]
        [SQLinqColumn("Name")]
        public String Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "")]
        [SQLinqColumn("PreviousName")]
        public String PreviousName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "")]
        [SQLinqColumn("CountryOfOriginId")]
        public Int32? CountryOfOriginId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "")]
        [SQLinqColumn("HK_ChineseName")]
        public String HK_ChineseName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "")]
        [SQLinqColumn("HK_BrandNumber")]
        public String HK_BrandNumber { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "")]
        [SQLinqColumn("SG_hasBled")]
        public Boolean? SG_hasBled { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "")]
        [SQLinqColumn("SexId")]
        public Int32? SexId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "")]
        [SQLinqColumn("CoatColorId")]
        public Int32? CoatColorId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "")]
        [SQLinqColumn("DateOfBirth")]
        public DateTime? DateOfBirth { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "")]
        [SQLinqColumn("SireName")]
        public String SireName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "")]
        [SQLinqColumn("DamName")]
        public String DamName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "")]
        [SQLinqColumn("isActive")]
        public Boolean? isActive { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "")]
        [SQLinqColumn("Z_MaxHcpRating")]
        public Int16? Z_MaxHcpRating { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "")]
        [SQLinqColumn("Z_CurrentHcpRating")]
        public Int16? Z_CurrentHcpRating { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "")]
        [SQLinqColumn("Z_StartSeasonHcpRating")]
        public Int16? Z_StartSeasonHcpRating { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "")]
        [SQLinqColumn("CountryOfRegistrationId")]
        public Int32? CountryOfRegistrationId { get; set; }

        public int CompareTo(Horse other)
        {
            return other == null?1:String.Compare(Name, other.Name, StringComparison.Ordinal);
        }
    }

}
