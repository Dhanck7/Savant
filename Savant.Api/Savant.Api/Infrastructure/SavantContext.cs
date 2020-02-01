using Microsoft.EntityFrameworkCore;

namespace Savant.Api.Infrastructure
{
    public class SavantContext : DbContext
    {
        public SavantContext()
        {

        }

        public SavantContext(DbContextOptions options)
            : base(options)
        {

        }
    }
}
