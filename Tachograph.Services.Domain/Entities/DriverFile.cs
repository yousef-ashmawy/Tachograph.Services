using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tachograph.Services.Domain.Entities
{
    public class DriverFile
    {
        public int Id { get; set; }
        public string Driver { get; set; }
        public List<TachographRecord> Records { get; set; } = new List<TachographRecord>();
        public TimeSpan DrivingStartTime { get; set; }
        public TimeSpan DrivingEndTime { get; set; }
    }
}
