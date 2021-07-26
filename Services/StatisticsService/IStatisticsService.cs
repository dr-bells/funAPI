using System.Threading.Tasks;
using funAPI.Models;

namespace funAPI.Services.StatisticsService
{
    public interface IStatisticsService
    {
        Task<ServiceResponse<double>> AverageNameLength();
    }
}