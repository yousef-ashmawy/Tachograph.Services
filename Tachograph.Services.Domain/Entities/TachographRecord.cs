using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tachograph.Services.Domain.Entities
{
    public class TachographRecord
    {
        public int id { get; set; }
        public string driver { get; set; }
        public DateOnly date { get; set; }
        public TimeOnly timestart { get; set; }
        public TimeOnly timeend { get; set; }
        public string activity { get; set; }
    }
}
