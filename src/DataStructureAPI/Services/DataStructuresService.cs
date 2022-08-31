using AlgorithmAPI.Client;
using AutoMapper;
using DataStructureAPI.Data;
using DataStructureAPI.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace DataStructureAPI.Services
{
    public class DataStructuresService : IDataStructuresService
    {
        private readonly DataStructureContext _context;
        private readonly IMapper _mapper;

        public DataStructuresService(DataStructureContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<DataStructureResponse> GetInfoAsync(string DataStructure)
        {
            var info = await _context.DataStructures.SingleOrDefaultAsync(s => s.Name.ToLower() == DataStructure);
            if (info == null)
                throw new NotFoundException("data structure not found");
            return _mapper.Map<DataStructureResponse>(info);
        }
    }
}