using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tachograph.Services.Domain.Entities;

namespace Tachograph.Services.Infrastructure.Interface
{
    public interface ITachographRecordRepo
    {
        Task<TachographRecord> GetByIdAsync(int id);
        Task<List<TachographRecord>> GetAllAsync();
        Task<List<TachographRecord>> GetAllByFilter(DateTime date);
        Task AddAsync(TachographRecord TachographRecord);
        void Delete(int id);
        Task UpdateAsync(TachographRecord TachographRecord);
        Task ProcessDataFromJsonFile(string filesPath);
    }
}
