namespace SB.Entity.Application.Implementations;
public class EntityApplication : IEntityApplication
{
    private readonly IEntityRepository _entityRepository;
    private readonly IMapper _mapper;

    public EntityApplication(IEntityRepository entityRepository, IMapper mapper)
    {
        _entityRepository = entityRepository;
        _mapper = mapper;
    }

    public async Task<List<EntitySearchDto>> GetAll(string? fact) { 
        IEnumerable<EntityModel> records = await _entityRepository.GetAll(fact);

        return _mapper.Map<List<EntitySearchDto>>(records);
    }

    public async Task<EntityDto> Get(int code) { 
        EntityModel? record = await _entityRepository.Get(code) ?? throw new ErrorException(StatusResponse.ERROR, "No existe registro");

        return _mapper.Map<EntityDto>(record);
    }

    public async Task<EntityDto> Post(EntitySaveDto record) {
        EntityModel entity = _mapper.Map<EntityModel>(record);

        entity = await _entityRepository.Post(entity);

        return _mapper.Map<EntityDto>(entity);
    }

    public async Task<EntityDto> Put(int code, EntityUpdateDto update) {
        EntityModel? record = await _entityRepository.Get(code) ?? throw new ErrorException(StatusResponse.ERROR, "No existe registro");

        _mapper.Map(update, record);

        record = await _entityRepository.Put(record);

        return _mapper.Map<EntityDto>(record);
    }

    public async Task<int> Delete(int code) {
        EntityModel? record = await _entityRepository.Get(code) ?? throw new ErrorException(StatusResponse.ERROR, "No existe registro");

        return await _entityRepository.Delete(record);
    }
}
