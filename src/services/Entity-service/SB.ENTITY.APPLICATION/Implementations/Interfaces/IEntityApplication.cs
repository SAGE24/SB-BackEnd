namespace SB.Entity.Application.Implementations.Interfaces;
public interface IEntityApplication
{
    Task<List<EntitySearchDto>> GetAll(string? fact);
    Task<EntityDto> Get(int code);
    Task<EntityDto> Post(EntitySaveDto record);
    Task<EntityDto> Put(int code, EntityUpdateDto update);
    Task<int> Delete(int code);
}
