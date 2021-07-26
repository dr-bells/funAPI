using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using funAPI.Data;
using funAPI.DTOs.Name;
using funAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace funAPI.Services.NameService
{
    public class NameService : INameService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public NameService(IMapper mapper, DataContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetNameDTO>>> AddAName(AddNameDTO newName)
        {
            var serviceResponse = new ServiceResponse<List<GetNameDTO>>();
            Names name = (_mapper.Map<Names>(newName));
            _context.Names.Add(name);
            await _context.SaveChangesAsync();
            serviceResponse.Data = await _context.Names.Select(c => _mapper.Map<GetNameDTO>(c)).ToListAsync();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetBookedNamesDTO>>> BookAName(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetBookedNamesDTO>>();

            try
            {
                Names name = await _context.Names.FirstAsync(n => n.Id == id);
                name.IsBooked = true;
                name.DateBooked = DateTime.UtcNow;
                await _context.SaveChangesAsync();
                serviceResponse.Data = _context.Names
                .Where(x => x.IsBooked == true)
                .Select(c => _mapper.Map<GetBookedNamesDTO>(c)).ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetNameDTO>>> DeleteAName(string role, int id)
        {
            var serviceResponse = new ServiceResponse<List<GetNameDTO>>();
            if (role.ToUpper() == "ADMIN")
            {
                try
                {
                    Names name = await _context.Names.FirstAsync(n => n.Id == id);
                    _context.Names.Remove(name);
                    await _context.SaveChangesAsync();
                    serviceResponse.Data = _context.Names.Select(c => _mapper.Map<GetNameDTO>(c)).ToList();
                }
                catch (Exception ex)
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = ex.Message;
                }
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetNameDTO>>> GenerateAName()
        {
            var serviceResponse = new ServiceResponse<List<GetNameDTO>>();
            string generatedName = NameGenerator.RandomString(10);
            Names name = new Names() { Name = generatedName };
            _context.Names.Add(name);
            await _context.SaveChangesAsync();
            serviceResponse.Data = await _context.Names
            .Where(n => n.DateGenerated.Date == DateTime.UtcNow.Date)
            .Select(n => _mapper.Map<GetNameDTO>(n))
            .ToListAsync();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetNameDTO>>> GetAll()
        {
            var serviceResponse = new ServiceResponse<List<GetNameDTO>>();
            var dbNames = await _context.Names.ToListAsync();
            serviceResponse.Data = dbNames.Select(c => _mapper.Map<GetNameDTO>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetBookedNamesDTO>>> GetBookedList(string role)
        {
            var serviceResponse = new ServiceResponse<List<GetBookedNamesDTO>>();

            if (role.ToUpper() == "ADMIN")
            {
                var dbNames = await _context.Names.Where(x => x.IsBooked).ToListAsync();
                serviceResponse.Data = dbNames.Select(n => _mapper.Map<GetBookedNamesDTO>(n)).ToList();
                return serviceResponse;
            }
            else
            {
                serviceResponse.Data = null;
                serviceResponse.Message = "Unfortunately you are restricted to access this information";
                return serviceResponse;
            }
        }

        public async Task<ServiceResponse<List<GetNameDTO>>> GetListForToday()
        {
            var serviceResponse = new ServiceResponse<List<GetNameDTO>>();
            var dbNames = await _context.Names
            .Where(x => x.DateGenerated.Date == DateTime.UtcNow.Date)
            .ToListAsync();
            serviceResponse.Data = dbNames.Select(c => _mapper.Map<GetNameDTO>(c)).ToList();
            return serviceResponse;
        }
    }
}