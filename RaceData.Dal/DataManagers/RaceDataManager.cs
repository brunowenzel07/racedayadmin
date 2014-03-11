using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DapperExtensions;
using RaceData.Dal.Core;
using RaceData.Dal.Core.CustomerRegistration.DAL.Core;
using RaceData.Dal.POCO;
using SQLinq;
using SQLinq.Dapper;

namespace RaceData.Dal.DataManagers
{
    public class RaceDataManager : BaseDataManager<Race>
    {
        public RaceDataManager(DbConnection connection) : base(connection)
        {
        }

        public List<Race> GetByMeetingId(int? meetingId)
        {
            List<Race> result = null;
            using (IDbConnection connection = _dbConnection.SqlConnection)
            {
                try
                {
                    connection.Open();
                    result =
                        connection.Query(from r in new SQLinq<Race>() where r.MeetingId == meetingId select r).ToList();
                }
                catch (Exception error)
                {
                    RdLogger.Error("Error during execute GetByMeetingId type:" + this.GetType(), error);
                }
                finally
                {
                    connection.Close();
                }
            }

            return result;
        }

        public override bool Insert(Race newEntity)
        {
            int result = 0;
            using (IDbConnection connection = _dbConnection.SqlConnection)
            {
                connection.Open();
                var sql =
                    "INSERT INTO [dbo].[Race] ([MeetingId],[RaceNumber],[RaceName],[RaceTypeId],[DistanceId],[RaceJumpTimeLocal],[HK_RaceIndex],[RaceWinningTime],[RaceGoingId],[isTurf],[NumberOfRunners],[isDone],[isStarted])" +
                    " VALUES (@MeetingId,@RaceNumber,@RaceName,@RaceTypeId,@DistanceId,@RaceJumpTimeLocal,@HK_RaceIndex,@RaceWinningTime,@RaceGoingId,@isTurf,@NumberOfRunners,@isDone,@isStarted)";
                try
                {
                    result = connection.Execute(sql, new
                                                     {
                                                         newEntity.MeetingId,
                                                         newEntity.RaceNumber,
                                                         newEntity.RaceName,
                                                         RaceTypeId =
                                                             newEntity.RaceTypeId == 0 ? null : newEntity.RaceTypeId,
                                                         DistanceId =
                                                             newEntity.DistanceId == 0 ? null : newEntity.DistanceId,
                                                         newEntity.RaceJumpDateTimeUTC,
                                                         newEntity.HK_RaceIndex,
                                                         RaceWinningTime = newEntity.RaceWinningTime.ToString(),
                                                         newEntity.RaceGoingId,
                                                         newEntity.isTurf,
                                                         NumberOfRunners = newEntity.NumberOfRunners,
                                                         newEntity.isDone,
                                                         newEntity.isStarted
                                                     });
                }
                catch (Exception error)
                {
                    RdLogger.Error("Error during execute Insert type:" + this.GetType(), error);    
                }
                finally
                {
                    connection.Close();
                } 

            }

            return result > 0;
        }

        public override bool Update(Race entity)
        {
            int result = 0;
            using (IDbConnection connection = _dbConnection.SqlConnection)
            {
                connection.Open();
                var sql =
                    "UPDATE [dbo].[Race] SET [MeetingId] = @MeetingId, [RaceNumber] = @RaceNumber, [RaceName] = @RaceName, [RaceTypeId] = @RaceTypeId " +
                    ",[DistanceId] = @DistanceId,[RaceJumpDateTimeUTC] = @RaceJumpDateTimeUTC,[HK_RaceIndex] = @HK_RaceIndex,[RaceWinningTime] = @RaceWinningTime " +
                    ",[RaceGoingId] = @RaceGoingId,[isTurf] = @isTurf,[NumberOfRunners] = @NumberOfRunners,[isDone] = @isDone, [isStarted] = @isStarted WHERE  Id=@Id";
                try
                {
                    result = connection.Execute(sql, new
                                                     {
                                                         entity.Id,
                                                         entity.MeetingId,
                                                         entity.RaceNumber,
                                                         entity.RaceName,
                                                         RaceTypeId = entity.RaceTypeId == 0 ? null : entity.RaceTypeId,
                                                         DistanceId = entity.DistanceId == 0 ? null : entity.DistanceId,
                                                         entity.RaceJumpDateTimeUTC,
                                                         entity.HK_RaceIndex,
                                                         RaceWinningTime = entity.RaceWinningTime.ToString(),
                                                         entity.RaceGoingId,
                                                         entity.isTurf,
                                                         NumberOfRunners = entity.NumberOfRunners,
                                                         entity.isDone,
                                                         entity.isStarted
                                                     });
                }
                catch (Exception error)
                {
                    RdLogger.Error("Error during execute Update type:" + this.GetType(), error);
                }
                finally
                {
                    connection.Close();
                }

            }

            return result > 0;
        }
    }
}
