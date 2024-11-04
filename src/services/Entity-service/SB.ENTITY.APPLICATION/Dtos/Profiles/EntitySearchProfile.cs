namespace SB.Entity.Application.Dtos.Profiles;
public class EntitySearchProfile : Profile
{
    public EntitySearchProfile() {
        CreateMap<EntityModel, EntitySearchDto>()
            .ForMember(dest => dest.CreationDate, opt => opt.MapFrom(src => src.CreationDate.ToString("dd/MM/yyyy HH:mm:ss")))
            .ForMember(dest => dest.ModificationDate, opt => opt.MapFrom(src => src.ModificationDate == null ? string.Empty : src.ModificationDate.Value.ToString("dd/MM/yyyy HH:mm:ss")))
            ;
    }
}
