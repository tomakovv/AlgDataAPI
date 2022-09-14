using AlgorithmAPI.Algorithm.Messaging.Send;
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
        private readonly ICalculationSender _calculationSender;

        public AlgorithmsController(ISortService sortService, ICalculationSender calculationSender)
        {
            _sortService = sortService;
            _calculationSender = calculationSender;
        }

        [HttpPost("HugeCalculation")]
        public IActionResult HugeCalculation(DataSetRead data)
        {
            _calculationSender.SendCalculation(data);
            return NoContent();
        }

        [HttpPost("BubbleSort")]
        public IActionResult BubbleSort(DataSetRead data) => Ok(_sortService.BubbleSort(data));

        [HttpPost("InsertionSort")]
        public IActionResult InsertionSort(DataSetRead data) => Ok(_sortService.InsertionSort(data));

        [HttpPost("MergeSort")]
        public IActionResult MergeSort(DataSetRead data) => Ok(_sortService.MergeSort(data));

        [HttpPost("QuickSort")]
        public IActionResult QuickSort(DataSetRead data) => Ok(_sortService.QuickSort(data));
    }
}