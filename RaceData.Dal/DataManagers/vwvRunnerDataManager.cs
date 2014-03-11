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
    public class vwvRunnerDataManager : BaseDataManager<vwvRunner>
    {
        public vwvRunnerDataManager(DbConnection connection) : base(connection)
        {
        }

        public List<vwvRunner> GetByRaceId(int? raceid)
        {
            List<vwvRunner> result = null;
            using (IDbConnection connection = _dbConnection.SqlConnection)
            {
                try
                {
                    connection.Open();
                    result =
                        connection.Query(from r in new SQLinq<vwvRunner>() where r.RaceId == raceid select r).ToList();
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
