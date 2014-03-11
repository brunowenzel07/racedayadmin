using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceData.Dal.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using NLog;

    namespace CustomerRegistration.DAL.Core
    {
        public class RdLogger
        {
            private static Logger _logger = LogManager.GetLogger("common");

            public static void Debug(string message)
            {
                _logger.Debug(() => message);
            }

            public static void Info(string message)
            {
                _logger.Info(() => message);
            }

            public static void Error(string message, Exception exception)
            {
                _logger.ErrorException(message, exception);
            }

            public static void Fatal(string message, Exception exception)
            {
                _logger.FatalException(message, exception);
            }
        }
    }

}
