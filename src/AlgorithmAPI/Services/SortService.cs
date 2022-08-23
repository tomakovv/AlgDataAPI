using AlgorithmAPI.Dto;
using AlgorithmAPI.Entities;

namespace AlgorithmAPI.Services
{
    public class SortService : ISortService
    {
        public DataSetResponse BubbleSort(DataSet data)
        {
            var values = data.Values;
            var watch = System.Diagnostics.Stopwatch.StartNew();
            var n = values.Count;
            for (int i = 0; i < n - 1; i++)
                for (int j = 0; j < n - i - 1; j++)
                    if (values[j] > values[j + 1])
                        (values[j], values[j + 1]) = (values[j + 1], values[j]);
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;

            return new DataSetResponse() { Data = values, TimeOfCalculation = elapsedMs };
        }

        public DataSetResponse InsertionSort(DataSet data)
        {
            var values = data.Values;
            var watch = System.Diagnostics.Stopwatch.StartNew();
            for (int i = 1; i < values.Count; i++)
            {
                var key = values[i];
                var flag = 0;
                for (int j = i - 1; j >= 0 && flag != 1;)
                {
                    if (key < values[j])
                    {
                        values[j + 1] = values[j];
                        j--;
                        values[j + 1] = key;
                    }
                    else flag = 1;
                }
            }
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            return new DataSetResponse() { Data = values, TimeOfCalculation = elapsedMs };
        }
    }
}