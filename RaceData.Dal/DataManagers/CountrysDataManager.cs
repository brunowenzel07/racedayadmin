using System;
using System.Data;
using System.Linq;
using RaceData.Dal.Core;
using RaceData.Dal.Core.CustomerRegistration.DAL.Core;
using RaceData.Dal.POCO;
using SQLinq;
using SQLinq.Dapper;

namespace RaceData.Dal.DataManagers
{
    public class CountrysDataManager : BaseDataManager<Country>
    {
        public CountrysDataManager(DbConnection connection) : base(connection)
        {
        }

        public int GetCountryIdByName(string countryName)
        {
            Country result = null;
            using (IDbConnection connection = _dbConnection.SqlConnection)
            {
                try
                {
                    connection.Open();
                    result =
                        connection.Query(from c in new SQLinq<Country>() where c.Name == countryName select c)
                            .FirstOrDefault();
                }
                catch (Exception error)
                {
                    RdLogger.Error("Error during execute GetCountryIdByName type:" + this.GetType(), error);
                }
                finally
                {
                    connection.Close();
                }
            }
            return result == null ? -1 : result.Id;
        }
    }
}
