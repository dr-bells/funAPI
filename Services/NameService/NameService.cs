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

        public async Task<ServiceResponse<List<GetNameDTO>>> BookAName(AddNameDTO newName)
        {
            var serviceResponse = new ServiceResponse<List<GetNameDTO>>();
            Name name = (_mapper.Map<Name>(newName));
            _context.Names.Add(name);
            await _context.SaveChangesAsync();
            serviceResponse.Data = await _context.Names.Select(c => _mapper.Map<GetNameDTO>(c)).ToListAsync();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetNameDTO>>> DeleteAName(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetNameDTO>>();
            try
            {
                Name name = await _context.Names.FirstAsync(n => n.Id == id);
                _context.Names.Remove(name);
                await _context.SaveChangesAsync();
                serviceResponse.Data = _context.Names.Select(c => _mapper.Map<GetNameDTO>(c)).ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetNameDTO>>> GetList()
        {
            var serviceResponse = new ServiceResponse<List<GetNameDTO>>();
            var dbNames = await _context.Names.ToListAsync();
            serviceResponse.Data = dbNames.Select(c => _mapper.Map<GetNameDTO>(c)).ToList();
            return serviceResponse;
        }
    }
}