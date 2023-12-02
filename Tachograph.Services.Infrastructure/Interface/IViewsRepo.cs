using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tachograph.Services.Domain.Entities;
using Tachograph.Services.Domain.Views;

namespace Tachograph.Services.Infrastructure.Interface
{
    public interface IViewsRepo
    {
        Task<List<VM_SingleDriveTimeViolations>> GetSingleDriveTimeViolations();
        Task<List<VM_SingleDriveTimeViolations>> GetSingleDriveTimeViolationsByFilter(DateTime date);
        Task<List<VM_RestTimeViolations>> GetRestTimeViolations();
        Task<List<VM_RestTimeViolations>> GetRestTimeViolationsByFilter(DateTime date);
        Task<List<VM_DayDriveTimeViolations>> GetDayDriveTimeViolations();
        Task<List<VM_DayDriveTimeViolations>> GetDayDriveTimeViolationsByFilter(DateTime date);

        Task<List<VM_WeekDriveTimeViolations>> GetWeekDriveTimeViolations();

    }
}
