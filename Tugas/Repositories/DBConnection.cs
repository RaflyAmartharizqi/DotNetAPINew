using Microsoft.EntityFrameworkCore;
using Tugas.Models.Entity;

namespace Tugas.Repositories
{
    public class DBConnection : DbContext
    {
        public DBConnection(DbContextOptions<DBConnection> opt) : base(opt) 
        {
            
        }

        public DbSet<StudentModel> Students { get; set; }
    }
}
