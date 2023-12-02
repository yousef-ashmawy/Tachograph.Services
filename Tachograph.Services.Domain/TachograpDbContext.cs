using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tachograph.Services.Domain.Entities;
using Tachograph.Services.Domain.Views;

namespace Tachograph.Services.Domain 
{
    public class TachograpDbContext : DbContext
    {
        public TachograpDbContext()
        {
            
        }
        public TachograpDbContext(DbContextOptions<TachograpDbContext> options)
            : base(options)
        {
        }

        #region Tables
        public virtual DbSet<TachographRecord> tachographrecord { get; set; }
        public virtual DbSet<Users> users { get; set; }
        #endregion

        #region Views

        public virtual DbSet<VM_SingleDriveTimeViolations> vm_singledrivetimeviolations { get; set; }
        public virtual DbSet<VM_RestTimeViolations> vm_resttimeviolations { get; set; }
        public virtual DbSet<VM_DayDriveTimeViolations> vm_daydrivetimeviolations { get; set; }
        public virtual DbSet<VM_WeekDriveTimeViolations> vm_weekdrivetimeviolations { get; set; }

        #endregion
    }
}
