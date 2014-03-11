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
    public class JockeyDataManager:BaseDataManager<Jockey>
    {
        public JockeyDataManager(DbConnection connection) : base(connection)
        {
        }

        public override List<Jockey> GetAll()
        {
            List<Jockey> result = null;
            using (IDbConnection connection = _dbConnection.SqlConnection)
            {
                try
                {
                    connection.Open();
                    result =
                        connection.Query(from jockey in new SQLinq<Jockey>() orderby jockey.Fullname select jockey)
                            .ToList();
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

        public List<vwvJockey> GetByCountryId(int? countryId)
        {
            List<vwvJockey> result = null;
            using (IDbConnection connection = _dbConnection.SqlConnection)
            {
                try
                {
                    connection.Open();
                    result = connection.Query(from jockey in new SQLinq<vwvJockey>()
                        where jockey.CountryOfRegistrationId == countryId
                        orderby jockey.Fullname
                        select jockey).ToList();
                }
                catch (Exception error)
                {
                    RdLogger.Error("Error during execute GetByCountryId type:" + this.GetType(), error);
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
