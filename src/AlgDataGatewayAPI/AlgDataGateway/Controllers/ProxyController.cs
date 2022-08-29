using AlgDataGateway.Extensions;
using AlgorithmAPI.Client;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace AlgDataGateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProxyController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public ProxyController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

        [HttpPost]
        public async Task<IActionResult> BubbleSort(DataSet data)
        => Ok(await _httpClient.DoPostAsync<DataSetResponse, DataSet>("http://localhost:5000/api/Algorithms/BubbleSort", data));

        [HttpPost]
        public async Task<IActionResult> InsertionSort(DataSet data)
        => Ok(await _httpClient.DoPostAsync<DataSetResponse, DataSet>("http://localhost:5000/api/Algorithms/InsertionSort", data));
    }
}