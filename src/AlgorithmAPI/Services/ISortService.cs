using AlgorithmAPI.Client;

namespace AlgorithmAPI.Services
{
    public interface ISortService
    {
        DataSetResponse BubbleSort(DataSet data);

        DataSetResponse InsertionSort(DataSet data);

        DataSetResponse MergeSort(DataSet data);

        DataSetResponse QuickSort(DataSet data);
    }
}