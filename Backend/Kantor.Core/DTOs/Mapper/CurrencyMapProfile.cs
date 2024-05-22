using AutoMapper;
using Kantor.Core.DTOs.Operation;

namespace Kantor.Core.DTOs.Mapper
{
    public class CurrencyMapProfile : Profile
    {
        public CurrencyMapProfile() 
        {
            CreateMap<CurrencyListItemDTO, CurrencyItemDTO>()
                .ForMember(dest => dest.Name,
                    opt => opt.MapFrom(x => x.Name))
                .ForMember(dest => dest.Purchase,
                    opt => opt.MapFrom(x => x.Price))
                .ForMember(dest => dest.Sale,
                    opt => opt.MapFrom(x => x.Price));
        }
    }
}
