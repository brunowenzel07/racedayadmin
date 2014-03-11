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
    public class GearDataManager:BaseDataManager<Gear>
    {
        public GearDataManager(DbConnection connection) : base(connection)
        {
        }

        public override List<Gear> GetAll()
        {
            List<Gear> result = null;
            using(IDbConnection connection = _dbConnection.SqlConnection)
            {
                try
                {
                    connection.Open();
                    result = connection.Query(from g in new SQLinq<Gear>() orderby g.Name select g).ToList();
                }
                catch (Exception error)
                {
                    RdLogger.Error("Error during execute GetAll type:" + this.GetType(), error);
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
