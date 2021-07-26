using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using funAPI.Data;
using funAPI.DTOs.Name;
using funAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace funAPI.Services.StatisticsService
{
    public class StatisticsService : IStatisticsService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public StatisticsService(IMapper mapper, DataContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<double>> AverageNameLength()
        {
            var serviceResponse = new ServiceResponse<double>();
            var dbNames = await _context.Names.ToListAsync();
            serviceResponse.Data = StatisticsCalculator.AverageNameLengthCalculator(dbNames);
            return serviceResponse;
        }
    }
}