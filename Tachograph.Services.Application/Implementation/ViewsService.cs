using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tachograph.Services.Domain.Entities;
using Tachograph.Services.Domain;
using Tachograph.Services.Domain.Views;
using Tachograph.Services.Infrastructure.Interface;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TachographServicesServices.Implementation
{   
    public class ViewsService : IViewsRepo
    {
        protected readonly ILogger<TachographRecord> _logger;
        private readonly TachograpDbContext _context;
        public ViewsService(TachograpDbContext context, ILogger<TachographRecord> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<List<VM_DayDriveTimeViolations>> GetDayDriveTimeViolations()
        {
            try
            {
                return await _context.vm_daydrivetimeviolations.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.InnerException?.Message ?? ex.Message);
                throw;
            }
        }

        public async Task<List<VM_DayDriveTimeViolations>> GetDayDriveTimeViolationsByFilter(DateTime date)
        {
            try
            {
                return await _context.vm_daydrivetimeviolations.Where(V => V.date == DateOnly.FromDateTime(date)).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.InnerException?.Message ?? ex.Message);
                throw;
            }
        }

        public async Task<List<VM_RestTimeViolations>> GetRestTimeViolations()
        {
            try
            {
                return await _context.vm_resttimeviolations.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.InnerException?.Message ?? ex.Message);
                throw;
            }
        }

        public async Task<List<VM_RestTimeViolations>> GetRestTimeViolationsByFilter(DateTime date)
        {
            try
            {
                return await _context.vm_resttimeviolations.Where(V => V.date == DateOnly.FromDateTime(date)).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.InnerException?.Message ?? ex.Message);
                throw;
            }
        }

        public async Task<List<VM_SingleDriveTimeViolations>> GetSingleDriveTimeViolations()
        {
            try
            {
                return await _context.vm_singledrivetimeviolations.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.InnerException?.Message ?? ex.Message);
                throw;
            }
        }

        public async Task<List<VM_SingleDriveTimeViolations>> GetSingleDriveTimeViolationsByFilter(DateTime date)
        {
            try
            {
                return await _context.vm_singledrivetimeviolations.Where(V => V.date == DateOnly.FromDateTime(date)).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.InnerException?.Message ?? ex.Message);
                throw;
            }
        }

        public async Task<List<VM_WeekDriveTimeViolations>> GetWeekDriveTimeViolations()
        {
            try
            {
                return await _context.vm_weekdrivetimeviolations.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.InnerException?.Message ?? ex.Message);
                throw;
            }
        }
    }
}
