using AutoMapper;
using Core.Entities;
using prestamos.Models;

namespace prestamos
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region People

            CreateMap<People, DropDownListViewModel>()
                .ForMember(d => d.Id, x => x.MapFrom(s => s.Id))
                .ForMember(d => d.Text, x => x.MapFrom(s => $"{s.Name} {s.Lastname}"));

            #endregion

            #region PaymentMethod

            CreateMap<PaymentMethod, DropDownListViewModel>()
                .ForMember(d => d.Id, x => x.MapFrom(s => s.Id))
                .ForMember(d => d.Text, x => x.MapFrom(s => s.Description));

            #endregion

            #region Term

            CreateMap<Term, DropDownListViewModel>()
                .ForMember(d => d.Id, x => x.MapFrom(s => s.Id))
                .ForMember(d => d.Text, x => x.MapFrom(s => s.Description));

            #endregion

            #region Loan

            CreateMap<Loan, DropDownListViewModel>()
                .ForMember(d => d.Id, x => x.MapFrom(s => s.Id))
                .ForMember(d => d.Text, x => x.MapFrom(s => s.Description));

            #endregion
        }
    }
}
