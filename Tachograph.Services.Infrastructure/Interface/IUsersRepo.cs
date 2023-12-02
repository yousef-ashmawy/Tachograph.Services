using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tachograph.Services.Domain.Entities;
using Tachograph.Services.Infrastructure.Models;

namespace Tachograph.Services.Infrastructure.Interface
{
    public interface IUsersRepo
    {
        Task<Users> GetByIdAsync(int id);
        Task<List<Users>> GetAllAsync();
        Task AddAsync(Users users);
        void Delete(int id);
        Task UpdateAsync(Users users);
        Task<LoginResponseModel> LoginAsync(LoginRequestModel loginRequestModel);
    }
}
