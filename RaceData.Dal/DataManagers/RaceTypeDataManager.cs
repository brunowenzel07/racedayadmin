using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Dapper;
using RaceData.Dal.Core;
using RaceData.Dal.Core.CustomerRegistration.DAL.Core;
using RaceData.Dal.DTO;
using RaceData.Dal.POCO;
using SQLinq;
using SQLinq.Dapper;

namespace RaceData.Dal.DataManagers
{
    public class RaceTypeDataManager :BaseDataManager<RaceType>
    {
        public RaceTypeDataManager(DbConnection connection) : base(connection)
        {
        }

        public override List<RaceType> GetAll()
        {
            using (IDbConnection connection = _dbConnection.SqlConnection)
            {
                List<RaceType> result = null;
                try
                {
                    connection.Open();
                    result = connection.Query(from rt in new SQLinq<RaceType>() orderby rt.Name select rt).ToList();
                }
                catch (Exception error)
                {
                    RdLogger.Error("Error during execute GetAll type:" + this.GetType(), error);
                }
                finally
                {
                    connection.Close();
                }

                return result;
            }
        }

        public List<RaceType> GetByCountryId(int? countryId)
        {
            List<RaceType> result = null;
            using (IDbConnection connection = _dbConnection.SqlConnection)
            {
                try
                {
                    connection.Open();
                    result =
                        connection.Query(from rt in new SQLinq<RaceType>() where rt.CountryId==countryId orderby rt.Name select rt).ToList();
                }
                finally
                {
                    connection.Close();
                }
            }

            return result;
        }

        public List<DTORaceType2> GetAllDto(int countryId)
        {
            List<DTORaceType2> result = null;
            var sql =
                "SELECT rt.Id ,rt.Name, rt.CountryId, c.Name AS CountryName, rt.isGroup FROM [dbo].[RaceType] rt LEFT JOIN Country c ON rt.CountryId = c.Id WHERE rt.CountryId=" + countryId;

            using (IDbConnection connection = _dbConnection.SqlConnection)
            {
                try
                {
                    connection.Open();
                    result = connection.Query<DTORaceType2>(sql).ToList();

                }
                catch (Exception error)
                {
                    RdLogger.Error("Error during execute GetAllDto type:" + this.GetType(), error);
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
