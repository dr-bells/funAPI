using System.Collections.Generic;
using System.Threading.Tasks;
using funAPI.DTOs.Statistics;
using funAPI.Models;

namespace funAPI.Services.StatisticsService
{
    public interface IStatisticsService
    {
        Task<ServiceResponse<double>> AverageNameLength();
        Task<ServiceResponse<int>> TotalNumberOfGeneratedNames();
        Task<ServiceResponse<int>> DailyGeneratedNames();
        Task<ServiceResponse<string>> GetLongestGeneratedName();
        Task<ServiceResponse<string>> GetShortestGeneratedName();
    }
}