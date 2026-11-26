using AutoMapper;

namespace Suppliers19;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Supplier, SupplierDto>();
        CreateMap<SupplierDto, Supplier>()
            .ForMember(s => s.Id, option => option.Ignore());
    }
}
