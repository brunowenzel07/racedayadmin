using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLinq;

namespace RaceData.Dal.POCO
{
    [SQLinqTable("vJockey")]
    public class vwvJockey
    {

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "")]
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
        [SQLinqColumn("Fullname")]
        public String Fullname { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "")]
        [SQLinqColumn("Gender")]
        public String Gender { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "")]
        [SQLinqColumn("isApprentice")]
        public Boolean? isApprentice { get; set; }

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
        [SQLinqColumn("CountryOfOrigin")]
        public string CountryOfOrigin { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "")]
        [SQLinqColumn("CountryOfRegistrationId")]
        public Int32? CountryOfRegistrationId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "")]
        [SQLinqColumn("CountryOfRegistration")]
        public string CountryOfRegistration { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "")]
        [SQLinqColumn("Fullnamevar")]
        public String Fullnamevar { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "")]
        [SQLinqColumn("Lastname")]
        public String Lastname { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "")]
        [SQLinqColumn("Firstname")]
        public String Firstname { get; set; }

    }
}
