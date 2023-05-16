using Microsoft.EntityFrameworkCore;
using projectv2.Shared.Models;

namespace projectv2.Server.Controllers.Data
{
    public class DatabaseContext: DbContext
    {

        public DatabaseContext(DbContextOptions<DatabaseContext> options) :base(options) { }
        public DbSet<Contact> contactus { get; set; }
    }
}
