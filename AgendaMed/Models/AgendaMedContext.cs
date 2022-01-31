using Microsoft.EntityFrameworkCore;

namespace AgendaMed.Models
{
    public class AgendaMedContext : DbContext
    {
        public AgendaMedContext(DbContextOptions<AgendaMedContext> options) : base(options)
        {

        }

        public DbSet<CadastroMedicos> CadastroMedicos { get; set;  }
    }
}
