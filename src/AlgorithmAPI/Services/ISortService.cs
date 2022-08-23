using AlgorithmAPI.Dto;
using AlgorithmAPI.Entities;

namespace AlgorithmAPI.Services
{
    public interface ISortService
    {
        public DataSetResponse BubbleSort(DataSet data);
        DataSetResponse InsertionSort(DataSet data);
    }
}