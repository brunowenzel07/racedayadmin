using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLinq;

namespace RaceData.Dal.POCO
{
    [SQLinqTable("Gear")]
    public class Gear : IComparable<Gear>
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
        [SQLinqColumn("Code")]
        public String Code { get; set; }

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
        [SQLinqColumn("CountryId")]
        public Int32? CountryId { get; set; }

        public int CompareTo(Gear other)
        {
            return other == null ? 1 : String.Compare(Name, other.Name, StringComparison.Ordinal);
        }
    }
}
