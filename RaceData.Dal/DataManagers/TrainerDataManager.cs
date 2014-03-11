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
    public class TrainerDataManager:BaseDataManager<Trainer>
    {
        public TrainerDataManager(DbConnection connection) : base(connection)
        {
        }

        public override List<Trainer> GetAll()
        {
            List<Trainer> result = null;
            using (IDbConnection connection = _dbConnection.SqlConnection)
            {
                try
                {
                    connection.Open();
                    result =
                        connection.Query(from trainer in new SQLinq<Trainer>() orderby trainer.Fullname select trainer)
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

        public  List<vwvTrainer> GetAllFromView()
        {
            List<vwvTrainer> result = null;
            using (IDbConnection connection = _dbConnection.SqlConnection)
            {
                try
                {
                    connection.Open();
                    result = connection.Query(from trainer in new SQLinq<vwvTrainer>() orderby trainer.Fullname select trainer).ToList();
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
