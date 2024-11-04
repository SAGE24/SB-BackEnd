namespace SB.Entity.Infrastructure.Repositories.Interfaces;
public interface IEntityRepository
{
    Task<IEnumerable<EntityModel>> GetAll(string fact);
    Task<EntityModel?> Get(int code);
    Task<EntityModel> Post(EntityModel entity);
    Task<EntityModel> Put(EntityModel record);
    Task<int> Delete(EntityModel record);
}
