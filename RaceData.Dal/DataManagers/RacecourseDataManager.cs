using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RaceData.Dal.Core.CustomerRegistration.DAL.Core;
using SQLinq;
using SQLinq.Dapper;
using RaceData.Dal.Core;
using RaceData.Dal.POCO;

namespace RaceData.Dal.DataManagers
{
    public class RacecourseDataManager :BaseDataManager<RaceCourse>
    {
        public RacecourseDataManager(DbConnection connection) : base(connection)
        {
        }

        public override List<RaceCourse> GetAll()
        {
            List<RaceCourse> result = null;
            using (IDbConnection connection = _dbConnection.SqlConnection)
            {
                try
                {
                    connection.Open();
                    result = connection.Query(from p in new SQLinq<RaceCourse>() orderby p.Name select p).ToList();
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
        public List<RaceCourse> GetByCountry(int? countryId)
        {
            List<RaceCourse> result = null;
            using (IDbConnection connection = _dbConnection.SqlConnection)
            {
                try
                {
                    connection.Open();
                    result =
                        connection.Query(from p in new SQLinq<RaceCourse>()
                            orderby p.Name
                            where p.CountryId == countryId
                            select p).ToList();
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
    }
}

