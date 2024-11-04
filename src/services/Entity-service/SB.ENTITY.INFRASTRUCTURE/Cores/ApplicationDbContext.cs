namespace SB.Entity.Infrastructure.Cores;
public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<EntityModel> EntitiesModel {  get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        ModelConfig(modelBuilder);
    }

    private static void ModelConfig(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new EntityConfiguration(modelBuilder));
    }
}
