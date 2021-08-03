using System.Collections.Generic;
using System.Threading.Tasks;
using funAPI.DTOs.Statistics;
using funAPI.Models;
using funAPI.Services.StatisticsService;
using Microsoft.AspNetCore.Mvc;

namespace funAPI.Controllers
{
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IStatisticsService _statisticsService;

        public StatisticsController(IStatisticsService statisticsService)
        {
            _statisticsService = statisticsService;

        }

        [HttpGet("AverageLength")]
        public async Task<ServiceResponse<double>> GetAverageNameLength()
        {
            return await _statisticsService.AverageNameLength();
        }

        [HttpGet("Generated/Total")]
        public async Task<ServiceResponse<int>> TotalGeneratedNames()
        {
            return await _statisticsService.TotalNumberOfGeneratedNames();
        }

        [HttpGet("Generated/Today")]
        public async Task<ServiceResponse<int>> NumberOfDailyGeneratedNames()
        {
            return await _statisticsService.DailyGeneratedNames();
        }

        [HttpGet("Generated/Longest")]
        public async Task<ServiceResponse<string>> LongestGeneratedName()
        {
            return await _statisticsService.GetLongestGeneratedName();
        }

        [HttpGet("Generated/Shortest")]
        public async Task<ServiceResponse<string>> ShortestGeneratedName()
        {
            return await _statisticsService.GetShortestGeneratedName();
        }

    }
}