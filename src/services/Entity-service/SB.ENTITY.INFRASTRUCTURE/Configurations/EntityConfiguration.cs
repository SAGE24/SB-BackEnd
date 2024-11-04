namespace SB.Entity.Infrastructure.Configurations;
public class EntityConfiguration : IEntityTypeConfiguration<EntityModel>
{
    public EntityConfiguration(ModelBuilder builder)
    {
        EntityTypeBuilder<EntityModel> entityBuilder = builder.Entity<EntityModel>();
        entityBuilder.ToTable("SB_ENTITIES");
        entityBuilder.HasKey(k => k.Code);
        entityBuilder.Property(c => c.Code).ValueGeneratedOnAdd();
        entityBuilder.Property(c => c.Code).HasColumnName("Entity_Code").IsRequired();
        entityBuilder.Property(c => c.Name).HasColumnName("Entity_Name").IsRequired();
        entityBuilder.Property(c => c.CreationDate).HasColumnName("Creation_Date").IsRequired();
        entityBuilder.Property(c => c.ModificationDate).HasColumnName("Modification_Date");
        Configure(entityBuilder);
    }

    public void Configure(EntityTypeBuilder<EntityModel> builder)
    {
    }
}
