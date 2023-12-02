using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tachograph.Services.Domain.Views
{
    [Keyless]
    public class VM_SingleDriveTimeViolations
    {
        public string driver { get; set; }
        public DateOnly date { get; set; }
    }
}
