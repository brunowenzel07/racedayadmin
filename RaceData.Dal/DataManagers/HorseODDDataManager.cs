using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RaceData.Dal.Core;
using RaceData.Dal.Core.CustomerRegistration.DAL.Core;
using RaceData.Dal.POCO;
using SQLinq;
using SQLinq.Dapper;

namespace RaceData.Dal.DataManagers
{
    public class HorseODDDataManager:BaseDataManager<HorseOdd>
    {
        public HorseODDDataManager(DbConnection connection) : base(connection)
        {
        }

        public List<HorseOdd> GetByRaceId(int? raceId)
        {
            List<HorseOdd> result = null;
            using (IDbConnection connection = _dbConnection.SqlConnection)
            {
                try
                {
                    connection.Open();
                    result =
                        connection.Query(from h in new SQLinq<HorseOdd>() where h.RaceId == raceId select h).ToList();
                }
                catch (Exception error)
                {
                    RdLogger.Error("Error during execute GetByRaceId type:" + this.GetType(), error);
                }
                finally
                {
                    connection.Close();
                }
            }
            return result;
        } 
    }
}
