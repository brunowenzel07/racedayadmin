using RaceData.Dal.Core;
using RaceData.Dal.POCO;

namespace RaceData.Dal.DataManagers
{
    public class CourseVariantDataManager :BaseDataManager<CourseVariant>
    {
        public CourseVariantDataManager(DbConnection connection) : base(connection)
        {
        }
    }
}
