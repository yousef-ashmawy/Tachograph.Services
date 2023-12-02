using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tachograph.Services.Domain;
using Tachograph.Services.Domain.Entities;
using Tachograph.Services.Infrastructure.Interface;

namespace TachographServicesServices.Implementation
{
    public class TachographRecordService : ITachographRecordRepo
    {
        protected readonly ILogger<TachographRecord> _logger;
        private readonly TachograpDbContext _context;

        public TachographRecordService(TachograpDbContext context, ILogger<TachographRecord> logger)
        {
            _context = context;
            _logger = logger;
        }

        public Task AddAsync(TachographRecord TachographRecord)
        {
            throw new NotImplementedException();
        }

        public async void Delete(int id)
        {
            try
            {
                var TachographRecord = _context.tachographrecord.AsNoTracking().SingleOrDefault(e => e.id == id);

                _context.tachographrecord.Remove(TachographRecord);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.InnerException?.Message ?? ex.Message);
                throw;
            }
        }

        public async Task<List<TachographRecord>> GetAllAsync()
        {
            try
            {
                return await _context.tachographrecord.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.InnerException?.Message ?? ex.Message);
                throw;
            }
        }

        public async Task<List<TachographRecord>> GetAllByFilter(DateTime date)
        {
            try
            {
                return await _context.tachographrecord.Where(V => V.date == DateOnly.FromDateTime(date)).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.InnerException?.Message ?? ex.Message);
                throw;
            }
        }
        
        public async Task<TachographRecord> GetByIdAsync(int id)
        {
            try
            {
                return await _context.tachographrecord.FindAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.InnerException?.Message ?? ex.Message);
                throw;
            }
        }

        public async Task UpdateAsync(TachographRecord TachographRecord)
        {
            try
            {
                if (TachographRecord != null)
                {
                    _context.tachographrecord.Update(TachographRecord);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.InnerException?.Message ?? ex.Message);
                throw;
            }
        }

        public async Task ProcessDataFromJsonFile(string filesPath)
        {
            try
            {
                string[] jsonFiles = Directory.GetFiles(filesPath, "*.json");                
                // Process each JSON file
                foreach (string jsonFile in jsonFiles)
                {
                    string jsonData = File.ReadAllText(jsonFile);
                    List<TachographRecord> data = JsonConvert.DeserializeObject<List<TachographRecord>>(jsonData);
                    foreach (var item in data)
                    {
                        await _context.tachographrecord.AddAsync(item);
                    }
                    await _context.SaveChangesAsync();
                    File.Delete(jsonFile);
                } 
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.InnerException?.Message ?? ex.Message);
                throw;
            }
        }

    }
}
