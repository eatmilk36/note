using Microsoft.EntityFrameworkCore;

namespace note.Entities.zero
{
   
public class ZeroDbContext : DbContext
{
    public static readonly ILoggerFactory MyLoggerFactory
        = LoggerFactory.Create(builder => builder.AddConsole());

    public ZeroDbContext(DbContextOptions<ZeroDbContext> options)
        : base(options)
    {
    }

    public DbSet<Zero> Department { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLoggerFactory(MyLoggerFactory);
    }
}

}