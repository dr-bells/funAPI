using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using funAPI.Data;
using funAPI.DTOs.Name;
using funAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FunAPICore.Services.AdminService
{
    public class AdminService : IAdminService
    {

        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public AdminService(IMapper mapper, DataContext context)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<List<GetNameDTO>>> DeleteAName(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetNameDTO>>();

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
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetBookedNamesDTO>>> GetBookedList()
        {
            var serviceResponse = new ServiceResponse<List<GetBookedNamesDTO>>();
            var namesFromDB = await _context.Names.Where(x => x.IsBooked).ToListAsync();
            serviceResponse.Data = namesFromDB.Select(n => _mapper.Map<GetBookedNamesDTO>(n)).ToList();
            return serviceResponse;
        }
    }
}