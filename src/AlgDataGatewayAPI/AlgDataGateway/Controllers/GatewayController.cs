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

        [HttpPost("BubbleSort")]
        public async Task<IActionResult> BubbleSort(DataSet data)
        => Ok(await _httpClient.DoPostAsync<DataSetResponse, DataSet>(_configuration["AlgorithmPaths:BubbleSort"], data));

        [HttpPost("InsertionSort")]
        public async Task<IActionResult> InsertionSort(DataSet data)
        => Ok(await _httpClient.DoPostAsync<DataSetResponse, DataSet>(_configuration["AlgorithmPaths: InsertionSort"], data));

        [HttpPost("MergeSort")]
        public async Task<IActionResult> MergeSort(DataSet data)
        => Ok(await _httpClient.DoPostAsync<DataSetResponse, DataSet>(_configuration["AlgorithmPaths: MergeSort"], data));

        [HttpPost("QuickSort")]
        public async Task<IActionResult> QuickSort(DataSet data)
        => Ok(await _httpClient.DoPostAsync<DataSetResponse, DataSet>(_configuration["AlgorithmPaths: QuickSort"], data));

        [HttpGet("Stack")]
        public async Task<IActionResult> StackInfo()
        => Ok(await _httpClient.DoGetAsync<DataStructureResponse>(_configuration["DataStructuresPaths: Stack"]));

        [HttpGet("Queue")]
        public async Task<IActionResult> QueueInfo()
        => Ok(await _httpClient.DoGetAsync<DataStructureResponse>(_configuration["DataStructuresPaths: Queue"]));

        [HttpGet("LinkedList")]
        public async Task<IActionResult> LinkedListInfo()
        => Ok(await _httpClient.DoGetAsync<DataStructureResponse>(_configuration["DataStructuresPaths: LinkedList"]));

        [HttpGet("HashTable")]
        public async Task<IActionResult> HashTableInfo()
        => Ok(await _httpClient.DoGetAsync<DataStructureResponse>(_configuration["DataStructuresPaths: HashTable"]));

        [HttpGet("BinarySearchTree")]
        public async Task<IActionResult> BinarySearchTreeInfo()
        => Ok(await _httpClient.DoGetAsync<DataStructureResponse>(_configuration["DataStructuresPaths: BinarySearchTree"]));

        [HttpGet("Graph")]
        public async Task<IActionResult> GraphInfo()
       => Ok(await _httpClient.DoGetAsync<DataStructureResponse>(_configuration["DataStructuresPaths: Graph"]));
    }
}