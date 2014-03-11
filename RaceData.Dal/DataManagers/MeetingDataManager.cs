using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using Dapper;
using RaceData.Dal.Core;
using RaceData.Dal.Core.CustomerRegistration.DAL.Core;
using RaceData.Dal.DTO;
using RaceData.Dal.POCO;
using SQLinq;
using SQLinq.Dapper;

namespace RaceData.Dal.DataManagers
{
    public class MeetingDataManager :BaseDataManager<Meeting>
    {
        public MeetingDataManager(DbConnection connection) : base(connection)
        {
        }

        public List<DtoMeeting> SearchMeetings(int? countryId, string racecourse, DateTime? startDate, DateTime? endDate)
        {
            var sql = "SELECT m.[Id],ISNULL(c.Code,'') AS CountryCode,[MeetingDate],ISNULL(rc.Name,'') AS RaceCourseName,[WeatherId],[DefaultGoingId],[NumberOfRaces]" +
                      ",[HK_isNightMeet],[CourseVariantId],[Z_MeetingCode],[isAbandoned],m.[MeetingCode] FROM [dbo].[Meeting] m " +
                      " LEFT JOIN Country c ON m.CountryId = c.Id LEFT JOIN RaceCourse rc ON m.RaceCourseId = rc.Id  WHERE m.CountryId="+countryId+" AND RaceCourseId="+racecourse;

         
            if (startDate != null && startDate != DateTime.MinValue)
            {
                sql += " AND MeetingDate>='" + startDate.Value.ToString(CultureInfo.InstalledUICulture.DateTimeFormat)+"'";
                
            }
            if (endDate != null && endDate != DateTime.MinValue)
                sql += " AND MeetingDate<='" + endDate.Value.ToString(CultureInfo.InstalledUICulture.DateTimeFormat) + "'";

            using (IDbConnection connection = _dbConnection.SqlConnection)
            {
                List<DtoMeeting> meetings = null;
                try
                {
                    connection.Open();
                    meetings =
                        connection.Query<DtoMeeting>(sql).ToList();
                }
                catch (Exception error)
                {
                    RdLogger.Error("Error during execute SearchMeetings type:" + this.GetType(), error);
                }
                finally
                {
                    connection.Close();
                }
              
                return meetings;
            }
        }

        public bool SearchDuplication(Meeting meeting)
        {
            bool result = false;
            using (IDbConnection connection = _dbConnection.SqlConnection)
            {
                try
                {
                    connection.Open();
                    result = connection.Query(
                        from m in new SQLinq<Meeting>()
                        where
                            m.MeetingDate == meeting.MeetingDate
                            && m.CountryId == meeting.CountryId
                            && m.RaceCourseId == meeting.RaceCourseId
                        select m).Any();

                }
                catch (Exception error)
                {
                    RdLogger.Error("Error during execute SearchDuplication type:" + this.GetType(), error);
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
