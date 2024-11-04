namespace SB.Entity.Application.Dtos.Profiles;
public class EntityProfile : Profile
{
    public EntityProfile() {
        CreateMap<EntityModel, EntityDto>();

        CreateMap<EntityModel, EntitySaveDto>().ReverseMap()
            .ForMember(dest => dest.CreationDate, opt => opt.MapFrom(src => DateTime.Now))
            ;

        CreateMap<EntityModel, EntityUpdateDto>().ReverseMap()
            .ForMember(dest => dest.ModificationDate, opt => opt.MapFrom(src => DateTime.Now))
            ;        
    }
}
