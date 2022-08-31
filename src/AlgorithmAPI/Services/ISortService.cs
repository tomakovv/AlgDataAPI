using AlgorithmAPI.Client;

namespace AlgorithmAPI.Services
{
    public interface ISortService
    {
        DataSetResponse BubbleSort(DataSetRead data);

        DataSetResponse InsertionSort(DataSetRead data);

        DataSetResponse MergeSort(DataSetRead data);

        DataSetResponse QuickSort(DataSetRead data);
    }
}