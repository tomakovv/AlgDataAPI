using AlgorithmAPI.Client;

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
            var elapsed = watch.Elapsed;

            return new DataSetResponse() { Data = values, TimeOfCalculation = elapsed };
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
            var elapsed = watch.Elapsed;
            return new DataSetResponse() { Data = values, TimeOfCalculation = elapsed };
        }

        public DataSetResponse MergeSort(DataSet data)
        {
            var values = data.Values;
            var left = 0;
            var right = values.Count - 1;
            var watch = System.Diagnostics.Stopwatch.StartNew();
            SortValues(values, left, right);
            watch.Stop();
            var elapsed = watch.Elapsed;
            return new DataSetResponse() { Data = values, TimeOfCalculation = elapsed };
        }

        public List<int> SortValues(List<int> values, int left, int right)
        {
            if (left < right)
            {
                int middle = left + (right - left) / 2;
                SortValues(values, left, middle);
                SortValues(values, middle + 1, right);
                MergeList(values, left, middle, right);
            }
            return values;
        }

        public void MergeList(List<int> array, int left, int middle, int right)
        {
            var leftArrayLength = middle - left + 1;
            var rightArrayLength = right - middle;
            var leftTempArray = new int[leftArrayLength];
            var rightTempArray = new int[rightArrayLength];
            int i, j;
            for (i = 0; i < leftArrayLength; ++i)
                leftTempArray[i] = array[left + i];
            for (j = 0; j < rightArrayLength; ++j)
                rightTempArray[j] = array[middle + 1 + j];
            i = 0;
            j = 0;
            int k = left;
            while (i < leftArrayLength && j < rightArrayLength)
            {
                if (leftTempArray[i] <= rightTempArray[j])
                {
                    array[k++] = leftTempArray[i++];
                }
                else
                {
                    array[k++] = rightTempArray[j++];
                }
            }
            while (i < leftArrayLength)
            {
                array[k++] = leftTempArray[i++];
            }
            while (j < rightArrayLength)
            {
                array[k++] = rightTempArray[j++];
            }
        }

        public DataSetResponse QuickSort(DataSet data)
        {
            var values = data.Values;
            var left = 0;
            var right = values.Count - 1;
            var watch = System.Diagnostics.Stopwatch.StartNew();
            QuickSortList(values, left, right);
            watch.Stop();
            var elapsed = watch.Elapsed;
            return new DataSetResponse() { Data = values, TimeOfCalculation = elapsed };
        }

        public List<int> QuickSortList(List<int> data, int leftIndex, int rightIndex)
        {
            var i = leftIndex;
            var j = rightIndex;
            var pivot = data[leftIndex];
            while (i <= j)
            {
                while (data[i] < pivot)
                {
                    i++;
                }

                while (data[j] > pivot)
                {
                    j--;
                }
                if (i <= j)
                {
                    (data[i], data[j]) = (data[j], data[i]);
                    i++;
                    j--;
                }
            }

            if (leftIndex < j)
                QuickSortList(data, leftIndex, j);
            if (i < rightIndex)
                QuickSortList(data, i, rightIndex);
            return data;
        }
    }
}