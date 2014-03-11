using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using RaceData.Dal.Core;
using RaceData.Dal.Core.CustomerRegistration.DAL.Core;
using RaceData.Dal.POCO;
using SQLinq;
using SQLinq.Dapper;

namespace RaceData.Dal.DataManagers
{
    public class DistanceDataManager: BaseDataManager<Distance>
    {
        public DistanceDataManager(DbConnection connection) : base(connection)
        {
        }

        public override List<Distance> GetAll()
        {
            List<Distance> result = null;
            using (IDbConnection connection = _dbConnection.SqlConnection)
            {
                try
                {
                    connection.Open();
                    result = connection.Query(from d in new SQLinq<Distance>() orderby d.Name select d).ToList();
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

        public List<Distance> GetByRaceCourse(int? rcId)
        {
            List<Distance> result = null;
            using (IDbConnection connection = _dbConnection.SqlConnection)
            {
                try
                {
                    connection.Open();
                    result =
                        connection.Query(from d in new SQLinq<Distance>() where d.RaceCourseID == rcId select d)
                            .ToList();
                }
                catch (Exception error)
                {
                    RdLogger.Error("Error during execute GetByRaceCourse type:" + this.GetType(), error);
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
