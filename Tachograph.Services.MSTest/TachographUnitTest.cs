using Microsoft.Extensions.Logging;
using Tachograph.Services.Domain;
using Tachograph.Services.Domain.Entities;
using Tachograph.Services.Infrastructure.Interface;
using TachographServicesServices.Implementation;

namespace Tachograph.Services.MSTest
{
    [TestClass]
    public class TachographUnitTest
    {
        [TestClass]
        public class TachographUT
        {
            private ITachographRecordRepo _itachographRecordRepo;
            protected readonly ILogger<TachographRecord> _logger;
            private readonly TachograpDbContext _context;
            public TachographUT(TachograpDbContext context, ILogger<TachographRecord> logger)
            {
                _context = context;
                _logger = logger;
                _itachographRecordRepo = new TachographRecordService(_context, _logger);
            }

            [TestMethod]
            public void GetAll()
            {
                //act
                var result = _itachographRecordRepo.GetAllAsync().Result;
                List<TachographRecord> value = result as List<TachographRecord>;

                //assert
                Assert.AreEqual(3, value.Count);
            }
            
        }
    }
}