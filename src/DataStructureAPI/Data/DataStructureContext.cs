using DataStructureAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataStructureAPI.Data
{
    public class DataStructureContext : DbContext
    {
        public DataStructureContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<DataStructure> DataStructures { get; set; }
    }
}