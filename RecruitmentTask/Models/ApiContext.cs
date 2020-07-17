using Microsoft.EntityFrameworkCore;

namespace RecruitmentTask.Models
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options) : base(options)
        {
        }

        public DbSet<FancyText> FancyTexts { get; set; }
    }
}
