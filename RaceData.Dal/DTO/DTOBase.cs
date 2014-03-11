using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceData.Dal.DTO
{
    public class DTOBase : IComparable
    {
        public int? Id { get; set; }
        public string Name { get; set; }
       

        public int CompareTo(object obj)
        {
            return obj == null || (obj as DTOBase) == null ? 1 : String.Compare(Name, (obj as DTOBase).Name, StringComparison.Ordinal);    
        }
    }
}
