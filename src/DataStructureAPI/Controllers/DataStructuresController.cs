using DataStructureAPI.Data;
using DataStructureAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace DataStructureAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataStructuresController : ControllerBase
    {
        private readonly IDataStructuresService _dataStructuresService;

        public DataStructuresController(DataStructureContext context, IDataStructuresService dataStructures)
        {
            _dataStructuresService = dataStructures;
        }

        [HttpGet("Stack")]
        public async Task<IActionResult> Stack() => Ok(await _dataStructuresService.GetInfoAsync("stack"));

        [HttpGet("Queue")]
        public async Task<IActionResult> Queue() => Ok(await _dataStructuresService.GetInfoAsync("queue"));

        [HttpGet("LinkedList")]
        public async Task<IActionResult> LinkedList() => Ok(await _dataStructuresService.GetInfoAsync("linked list"));

        [HttpGet("HashTable")]
        public async Task<IActionResult> HashTable() => Ok(await _dataStructuresService.GetInfoAsync("hash table"));

        [HttpGet("BinarySearchTree")]
        public async Task<IActionResult> BinarySearch() => Ok(await _dataStructuresService.GetInfoAsync("binary search tree"));

        [HttpGet("Graph")]
        public async Task<IActionResult> Graph() => Ok(await _dataStructuresService.GetInfoAsync("graph"));
    }
}