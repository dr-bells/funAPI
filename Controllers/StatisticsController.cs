using System.Threading.Tasks;
using funAPI.Models;
using funAPI.Services.StatisticsService;
using Microsoft.AspNetCore.Mvc;

namespace funAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StatisticsController : ControllerBase
    {
        private readonly IStatisticsService _statisticsService;

        public StatisticsController(IStatisticsService statisticsService)
        {
            _statisticsService = statisticsService;

        }

        [HttpGet("AverageNameLength")]
        public async Task<ServiceResponse<double>> GetAverageNameLength()
        {
            return await _statisticsService.AverageNameLength();
        }
    }
}