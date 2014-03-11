using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLinq;

namespace RaceData.Dal.POCO
{
    [SQLinqTable("Sex")]
    public class Sex 
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
        [SQLinqColumn("Name")]
        public String Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "")]
        [SQLinqColumn("Code")]
        public String Code { get; set; }

    }
}
