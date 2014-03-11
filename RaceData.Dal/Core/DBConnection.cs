using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceData.Dal.Core
{
    public class DbConnection
    {
        public SqlConnection SqlConnection
        {
            get
            {
                ConnectionStringSettings connectionString = ConfigurationManager.ConnectionStrings["RDEntities"];
                if (connectionString == null)
                    throw new Exception("Please set RDEntities connection in Web.config.");

                return new SqlConnection(connectionString.ConnectionString);
            }
        }

        public DbConnection()
        {
        }
    }
}