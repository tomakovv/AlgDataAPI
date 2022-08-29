using DataStructureAPI.Data;
using DataStructureAPI.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DataStructureAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataStructuresController : ControllerBase
    {
        private readonly DataStructureContext _context;

        public DataStructuresController(DataStructureContext context)
        {
            _context = context;
        }

        [HttpGet("Stack")]
        public async Task<IActionResult> Stack()
        {
            return Ok(_context.DataStructures.Where(s => s.Id == 1));
        }

        [HttpPost]
        public IActionResult Structure()
        {
            _context.DataStructures.Add(new DataStructure() { BigONotationValue = "2", Description = "dasd", Name = "dasds" });
            _context.SaveChanges();
            return Ok();
        }
    }
}