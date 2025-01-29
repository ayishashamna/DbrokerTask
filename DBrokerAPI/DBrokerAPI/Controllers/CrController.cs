using DBrokerAPI.Data;
using DBrokerAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DBrokerAPI.Controllers
{
    [Route("api/cr")]
    [ApiController]
    public class CrController : ControllerBase
    {
        private readonly CrDbContext _dbContext;
        public CrController( CrDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpPost]
        public IActionResult GetCrData([FromBody] CrRequest crRequest)
        {
            if (string.IsNullOrEmpty(crRequest.CrNumber))
            {
                return BadRequest("CrNumber is required.");
            }
            // Return dummy data for testing
            var data = new CRData
            {
                NameEn = "Mohammed",
                NameAr = "محمد",
                CrNumber = crRequest.CrNumber
            };
            return Ok(data);
        }

        [HttpPost("save")]
        public async Task<IActionResult> SaveCrData([FromBody] CRData data)
        {
            try
            {
                // Save data to SQL Server using Entity Framework Core
                await _dbContext.CRDatas.AddAsync(data);
                await _dbContext.SaveChangesAsync();
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest();
            }
           
        }

        //To perfectly bind the crNumber passed from the frontend, created CrRequest class
        public class CrRequest
        {
            public string CrNumber { get; set; }
        }
    }
}
