using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DapperExtensions;
using RaceData.Dal.Core.CustomerRegistration.DAL.Core;
using RaceData.Dal.POCO;
using SQLinq;
using SQLinq.Dapper;

namespace RaceData.Dal.Core
{
    public class BaseDataManager<T> where T : class, new()
    {
        protected DbConnection _dbConnection;

        public BaseDataManager(DbConnection connection)
        {
            _dbConnection = connection;
        }
        public virtual List<T> GetAll()
        {
            List<T> result = null;
            using (IDbConnection connection = _dbConnection.SqlConnection)
            {
                try
                {
                    connection.Open();
                    result = connection.Query(from p in new SQLinq<T>() select p).ToList();
                }
                catch (Exception error)
                {
                    RdLogger.Error("Error during execute GetAll type:" + typeof (T).ToString(), error);
                }
                finally
                {
                    connection.Close();
                }
            }

            return result;
        }

        public T GetById(int? id)
        {
            T result = null;
            if (id != null)
            {
                using (IDbConnection connection = _dbConnection.SqlConnection)
                {
                    try
                    {
                        connection.Open();
                        result = connection.Get<T>(id);
                    }
                    catch (Exception error)
                    {
                        RdLogger.Error("Error during execute GetById type:" + typeof(T).ToString(), error);
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
            return result;
        } 

        public virtual bool Insert(T newEntity)
        {
            int result = -1;
            using (IDbConnection connection = _dbConnection.SqlConnection)
            {
                try
                {
                    connection.Open();
                    result = connection.Insert(newEntity);
                }
                catch (Exception error)
                {
                    RdLogger.Error("Error during execute Insert type:" + typeof(T).ToString(), error);
                }
                finally
                {
                    connection.Close();
                }
            }

            return result>0;
        }

        public virtual bool Update(T entity)
        {
            bool result = false;
            using (IDbConnection connection = _dbConnection.SqlConnection)
            {
                try
                {
                    connection.Open();
                    result = connection.Update(entity);
                }
                catch (Exception error)
                {
                    RdLogger.Error("Error during execute Update type:" + typeof(T).ToString(), error);
                }
                finally
                {
                    connection.Close();
                }
            }

            return result;
        }

        public virtual bool Delete(T entry)
        {
            bool result = false;
            using (IDbConnection connection = _dbConnection.SqlConnection)
            {
                try
                {
                    connection.Open();
                    result = connection.Delete(entry, null, null);
                }
                catch (Exception error)
                {
                    RdLogger.Error("Error during execute Delete type:" + typeof(T).ToString(), error);
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
