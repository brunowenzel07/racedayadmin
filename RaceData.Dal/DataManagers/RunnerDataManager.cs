using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using RaceData.Dal.Core;
using RaceData.Dal.Core.CustomerRegistration.DAL.Core;
using RaceData.Dal.POCO;
using SQLinq;
using SQLinq.Dapper;


namespace RaceData.Dal.DataManagers
{
    public class RunnerDataManager :BaseDataManager<Runner>
    {
        public RunnerDataManager(DbConnection connection) : base(connection)
        {
        }

        public List<Runner> GetByRaceId(int? raiceId)
        {
            List<Runner> result = null;
            using (IDbConnection connection = _dbConnection.SqlConnection)
            {
                try
                {
                    connection.Open();
                    result =
                        connection.Query(from r in new SQLinq<Runner>() where r.RaceId == raiceId select r).ToList();

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
