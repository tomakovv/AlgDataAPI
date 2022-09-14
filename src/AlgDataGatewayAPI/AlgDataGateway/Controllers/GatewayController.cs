using AlgDataGateway.Extensions;
using AlgorithmAPI.Client;
using Microsoft.AspNetCore.Mvc;

namespace AlgDataGateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GatewayController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        private readonly IConfiguration _configuration;

        public GatewayController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClient = httpClientFactory.CreateClient();
            _configuration = configuration;
        }

        [HttpPost("HugeCalculation")]
        public async Task<IActionResult> HugeCalculation(DataSetRead data)
        {
            await _httpClient.PostAsJsonAsync(_configuration["AlgorithmPaths:HugeCalculation"], data);
            return Ok();
        }

        [HttpPost("BubbleSort")]
        public async Task<IActionResult> BubbleSort(DataSetRead data)
        => Ok(await _httpClient.DoPostAsync<DataSetResponse, DataSetRead>(_configuration["AlgorithmPaths:BubbleSort"], data));

        [HttpPost("InsertionSort")]
        public async Task<IActionResult> InsertionSort(DataSetRead data)
        => Ok(await _httpClient.DoPostAsync<DataSetResponse, DataSetRead>(_configuration["AlgorithmPaths:InsertionSort"], data));

        [HttpPost("MergeSort")]
        public async Task<IActionResult> MergeSort(DataSetRead data)
        => Ok(await _httpClient.DoPostAsync<DataSetResponse, DataSetRead>(_configuration["AlgorithmPaths:MergeSort"], data));

        [HttpPost("QuickSort")]
        public async Task<IActionResult> QuickSort(DataSetRead data)
        => Ok(await _httpClient.DoPostAsync<DataSetResponse, DataSetRead>(_configuration["AlgorithmPaths:QuickSort"], data));

        [HttpGet("Stack")]
        public async Task<IActionResult> StackInfo()
        => Ok(await _httpClient.DoGetAsync<DataStructureResponse>(_configuration["DataStructuresPaths:Stack"]));

        [HttpGet("Queue")]
        public async Task<IActionResult> QueueInfo()
        => Ok(await _httpClient.DoGetAsync<DataStructureResponse>(_configuration["DataStructuresPaths:Queue"]));

        [HttpGet("LinkedList")]
        public async Task<IActionResult> LinkedListInfo()
        => Ok(await _httpClient.DoGetAsync<DataStructureResponse>(_configuration["DataStructuresPaths:LinkedList"]));

        [HttpGet("HashTable")]
        public async Task<IActionResult> HashTableInfo()
        => Ok(await _httpClient.DoGetAsync<DataStructureResponse>(_configuration["DataStructuresPaths:HashTable"]));

        [HttpGet("BinarySearchTree")]
        public async Task<IActionResult> BinarySearchTreeInfo()
        => Ok(await _httpClient.DoGetAsync<DataStructureResponse>(_configuration["DataStructuresPaths:BinarySearchTree"]));

        [HttpGet("Graph")]
        public async Task<IActionResult> GraphInfo()
       => Ok(await _httpClient.DoGetAsync<DataStructureResponse>(_configuration["DataStructuresPaths:Graph"]));
    }
}