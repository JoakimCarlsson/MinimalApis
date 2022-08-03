namespace MinimalApis.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<Car> Cars => Set<Car>();
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
}