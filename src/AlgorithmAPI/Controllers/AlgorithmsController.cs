using AlgorithmAPI.Client;
using AlgorithmAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace AlgorithmAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlgorithmsController : ControllerBase
    {
        private readonly ISortService _sortService;

        public AlgorithmsController(ISortService sortService)
        {
            _sortService = sortService;
        }

        [HttpPost("BubbleSort")]
        public IActionResult BubbleSort(DataSet data) => Ok(_sortService.BubbleSort(data));

        [HttpPost("InsertionSort")]
        public IActionResult InsertionSort(DataSet data) => Ok(_sortService.InsertionSort(data));

        [HttpPost("MergeSort")]
        public IActionResult MergeSort(DataSet data) => Ok(_sortService.MergeSort(data));

        [HttpPost("QuickSort")]
        public IActionResult QuickSort(DataSet data) => Ok(_sortService.QuickSort(data));
    }
}