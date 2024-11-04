namespace SB.Entity.Infrastructure.Repositories;
public class EntityRepository : IEntityRepository
{
    private readonly ApplicationDbContext _context;

    public EntityRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<EntityModel>> GetAll(string fact) {
        IQueryable<EntityModel> query = _context.EntitiesModel
            .AsQueryable()
            .AsNoTracking();

        if (!string.IsNullOrEmpty(fact)) {
            query = query.Where(w => w.Code.ToString().Contains(fact) || w.Name.Contains(fact));
        }

        return await query.OrderByDescending(o => o.Code).ToListAsync();
    }

    public async Task<EntityModel?> Get(int code) {
        EntityModel? record = await _context.EntitiesModel.FindAsync(code);

        return record;
    }

    public async Task<EntityModel> Post(EntityModel entity) { 
        _context.EntitiesModel.Add(entity);
        await _context.SaveChangesAsync();

        return entity;
    }

    public async Task<EntityModel> Put(EntityModel record) {

        await _context.SaveChangesAsync();

        return record;
    }

    public async Task<int> Delete(EntityModel record) {
        int code = record.Code;

        _context.Remove(record);

        await _context.SaveChangesAsync();

        return code;
    }
}
