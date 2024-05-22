using AutoMapper;
using Kantor.Core.DTOs.Account;
using Kantor.Core.DTOs.Operation;
using Kantor.Core.DTOs.User;
using Kantor.Infrastructure.Entities.Account;
using Kantor.Infrastructure.Entities.Operations;
using Kantor.Infrastructure.Entities.User;

namespace Kantor.Core.DTOs.Mapper
{
    public class UserMapProfile : Profile
    {
        public UserMapProfile() 
        {
            CreateMap<Infrastructure.Entities.User.User, UserDetailsDTO>()
                .ForMember(dest => dest.History,
                    opt => opt.MapFrom(x => x.History))
                .ForMember(dest => dest.OperationHistory,
                    opt => opt.MapFrom(x => x.OperationHistory))
                .ForMember(dest => dest.AccountBalances,
                    opt => opt.MapFrom(x => x.Account.AccountBalances));

            CreateMap<UserHistory, UserHistoryDTO>();

            CreateMap<OperationHistory, OperationHistoryDTO>()
                .ForMember(dest => dest.OperationType,
                    opt => opt.MapFrom(x => x.OperationType.Name))
                .ForMember(dest => dest.OperationTypeId,
                    opt => opt.MapFrom(x => x.OperationType.Id))
                .ForMember(dest => dest.CurrencyCode,
                    opt => opt.MapFrom(x => x.Currency.Code))
                .ForMember(dest => dest.CurrencyId,
                    opt => opt.MapFrom(x => x.Currency.Id));

            CreateMap<AccountBalance, AccountBalanceDTO>()
                .ForMember(dest => dest.Currency,
                    opt => opt.MapFrom(x => x.Currency.Code));
        }
    }
}
