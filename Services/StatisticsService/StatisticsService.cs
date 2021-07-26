using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using funAPI.Data;
using funAPI.DTOs.Name;
using funAPI.DTOs.Statistics;
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
            if (dbNames.Count != 0)
                serviceResponse.Data = StatisticsCalculator.AverageNameLengthCalculator(dbNames);
            else
                serviceResponse.Message = "The Database is empty";
            return serviceResponse;
        }

        public async Task<ServiceResponse<int>> DailyGeneratedNames()
        {
            var serviceResponse = new ServiceResponse<int>();
            var dbNames = await _context.Names
            .Where(n => n.DateGenerated.Date == DateTime.UtcNow.Date).ToListAsync();
            serviceResponse.Data = dbNames.Count();
            return serviceResponse;
        }

        public async Task<ServiceResponse<string>> GetLongestGeneratedName()
        {
            var serviceResponse = new ServiceResponse<string>();
            var dbNames = await _context.Names.ToListAsync();
            if (dbNames.Count != 0)
                serviceResponse.Data = StatisticsCalculator.LongestGeneratedName(dbNames);
            else
                serviceResponse.Message = "The Database is empty";
            return serviceResponse;
        }

        public async Task<ServiceResponse<string>> GetShortestGeneratedName()
        {
            var serviceResponse = new ServiceResponse<string>();
            var dbNames = await _context.Names.ToListAsync();
            if (dbNames.Count != 0)
                serviceResponse.Data = StatisticsCalculator.ShortestGeneratedName(dbNames);
            else
                serviceResponse.Message = "The Database is empty";
            return serviceResponse;
        }

        public async Task<ServiceResponse<int>> TotalNumberOfGeneratedNames()
        {
            var serviceResponse = new ServiceResponse<int>();
            var dbNames = await _context.Names.ToListAsync();
            if (dbNames.Count != 0)
                serviceResponse.Data = dbNames.Count;
            else
                serviceResponse.Message = "The Database is empty";
            return serviceResponse;
        }
    }
}