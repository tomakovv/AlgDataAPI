using AlgorithmAPI.Client;

namespace DataStructureAPI.Services
{
    public interface IDataStructuresService
    {
        Task<DataStructureResponse> GetInfoAsync(string dataStructure);
    }
}