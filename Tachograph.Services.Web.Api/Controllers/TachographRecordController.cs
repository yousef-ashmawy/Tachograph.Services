using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tachograph.Services.Domain.Entities;
using Tachograph.Services.Domain.Views;
using Tachograph.Services.Infrastructure.Interface;
using TachographServicesServices.Implementation;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Tachograph.Services.Web.Api.Controllers
{
    [Route("api/TachographServices/[controller]/[action]")]
    [ApiController]
    // [Authorize]
    public class TachographRecordController : ControllerBase
    {
        private readonly ITachographRecordRepo _itachographRecordRepo;
        private readonly IViewsRepo _iviewsRepo;
        public TachographRecordController(ITachographRecordRepo itachographRecordRepo, IViewsRepo iviewsRepo)
        {
            _itachographRecordRepo = itachographRecordRepo;
            _iviewsRepo = iviewsRepo;

        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                var result = await _itachographRecordRepo.GetAllAsync();
                return Ok(result);
            }
            catch
            {
                throw;
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetAllByFilter(DateTime date)
        {
            try
            {
                var result = await _itachographRecordRepo.GetAllByFilter(date);
                return Ok(result);
            }
            catch
            {
                throw;
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetSingleDriveTimeViolations()
        {
            try
            {
                var result = await _iviewsRepo.GetSingleDriveTimeViolations();
                return Ok(result);
            }
            catch
            {
                throw;
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetSingleDriveTimeViolationsByFilter(DateTime date)
        {
            try
            {
                var result = await _iviewsRepo.GetSingleDriveTimeViolationsByFilter(date);
                return Ok(result);
            }
            catch
            {
                throw;
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetRestTimeViolations()
        {
            try
            {
                var result = await _iviewsRepo.GetRestTimeViolations();
                return Ok(result);
            }
            catch
            {
                throw;
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetRestTimeViolationsByFilter(DateTime date)
        {
            try
            {
                var result = await _iviewsRepo.GetRestTimeViolationsByFilter(date);
                return Ok(result);
            }
            catch
            {
                throw;
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetDayDriveTimeViolations()
        {
            try
            {
                var result = await _iviewsRepo.GetDayDriveTimeViolations();
                return Ok(result);
            }
            catch
            {
                throw;
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetDayDriveTimeViolationsByFilter(DateTime date)
        {
            try
            {
                var result = await _iviewsRepo.GetDayDriveTimeViolationsByFilter(date);
                return Ok(result);
            }
            catch
            {
                throw;
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetWeekDriveTimeViolations()
        {
            try
            {
                var result = await _iviewsRepo.GetWeekDriveTimeViolations();
                return Ok(result);
            }
            catch
            {
                throw;
            }
        }

    }
}
