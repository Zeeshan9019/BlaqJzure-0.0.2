using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaqJzure.Common.Services
{
    public static class TimeService
    {
        public static DateTime Now()
        {
            return DateTime.Now;
        }
        public static DateTime PakistanNow()
        {
            return DateTime.UtcNow.AddHours(5);
        }
    }
}
