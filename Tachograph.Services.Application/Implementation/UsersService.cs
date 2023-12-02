using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tachograph.Services.Domain.Entities;
using Tachograph.Services.Domain;
using Microsoft.EntityFrameworkCore;
using Tachograph.Services.Infrastructure.Interface;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Tachograph.Services.Infrastructure.Models;
using System.ComponentModel.DataAnnotations;

namespace TachographServicesServices.Implementation
{
    public class UsersService : IUsersRepo
    {
        protected readonly ILogger<Users> _logger;
        private readonly TachograpDbContext _context;

        public UsersService(TachograpDbContext context, ILogger<Users> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task AddAsync(Users Users)
        {
            try
            {
                if (Users != null)
                {
                    await _context.users.AddAsync(Users);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.InnerException?.Message ?? ex.Message);
                throw;
            }
        }

        public async void Delete(int id)
        {
            try
            {
                var Users = _context.users.AsNoTracking().SingleOrDefault(e => e.id == id);

                _context.users.Remove(Users);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.InnerException?.Message ?? ex.Message);
                throw;
            }
        }

        public async Task<List<Users>> GetAllAsync()
        {
            try
            {
                return await _context.users.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.InnerException?.Message ?? ex.Message);
                throw;
            }
        }

        public async Task<Users> GetByIdAsync(int id)
        {
            try
            {
                return await _context.users.FindAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.InnerException?.Message ?? ex.Message);
                throw;
            }
        }    

        public async Task UpdateAsync(Users Users)
        {
            try
            {
                if (Users != null)
                {
                    _context.users.Update(Users);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.InnerException?.Message ?? ex.Message);
                throw;
            }
        }

        public async Task<LoginResponseModel> LoginAsync(LoginRequestModel loginRequestModel)
        {
            try
            {
                var user = await _context.users.SingleOrDefaultAsync(u => u.email == loginRequestModel.Email && u.password == loginRequestModel.Password);
                if (user is null)
                    throw new ValidationException("Email Or Password InValid");

                var userModel = new LoginResponseModel
                {
                    Id = user.id,
                    email = user.email
                };

                userModel.Token = generateJwtToken(user.id);
                return userModel;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.InnerException?.Message ?? ex.Message);
                throw;
            }
        }

        public string generateJwtToken(int userId)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("+ scania Tachograp @ 123 key secret");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", userId.ToString()) }),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
