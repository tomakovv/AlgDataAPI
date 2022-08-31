using AlgorithmAPI.Client;
using AutoMapper;

namespace DataStructureAPI.Mapper
{
    public class DataStructureProfile : Profile
    {
        public DataStructureProfile()
        {
            CreateMap<DataStructure, DataStructureResponse>();
        }
    }
}