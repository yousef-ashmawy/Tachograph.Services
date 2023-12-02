using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tachograph.Services.Domain.Views
{
    public class VM_DayDriveTimeViolations
    {
        public int id { get; set; }
        public string driver { get; set; }
        public DateOnly date { get; set; }
        public TimeOnly timestart { get; set; }
        public TimeOnly timeend { get; set; }
        public string activity { get; set; }
    }
}
