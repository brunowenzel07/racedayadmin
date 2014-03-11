using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RaceData.Dal.Core;
using RaceData.Dal.POCO;

namespace RaceData.Dal.DataManagers
{
    public class SexDataManager:BaseDataManager<Sex>
    {
        public SexDataManager(DbConnection connection) : base(connection)
        {
        }


    }
}
