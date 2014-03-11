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
    public class HorseDataManager :BaseDataManager<Horse>
    {
        public HorseDataManager(DbConnection connection) : base(connection)
        {
        }

        public override List<Horse> GetAll()
        {
            List<Horse> result = null;
            using (IDbConnection connection = _dbConnection.SqlConnection)
            {
                try
                {
                    connection.Open();
                    result = connection.Query(from h in new SQLinq<Horse>() orderby h.Name select h).ToList();
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

        public List<Horse> GetByCountry(int? countryId)
        {
            List<Horse> result = null;
            using (IDbConnection connection = _dbConnection.SqlConnection)
            {
                try
                {
                    connection.Open();
                    result =
                        connection.Query(from h in new SQLinq<Horse>()
                            where h.CountryOfRegistrationId == countryId
                            orderby h.Name
                            select h).ToList();
                }
                catch (Exception error)
                {
                    RdLogger.Error("Error during execute GetByCountry type:" + this.GetType(), error);
                }
                finally
                {
                    connection.Close();
                }
            }

            return result;
        }

        public List<vwvHorse> GetByCountryFromView(int? countryId)
        {
            List<vwvHorse> result = null;
            using (IDbConnection connection = _dbConnection.SqlConnection)
            {
                try
                {
                    connection.Open();
                    result =
                        connection.Query(from h in new SQLinq<vwvHorse>()
                            where h.CountryOfRegistrationId == countryId
                            orderby h.Name
                            select h).ToList();
                }
                catch (Exception error)
                {
                    RdLogger.Error("Error during execute GetByCountryFromView type:" + this.GetType(), error);
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
