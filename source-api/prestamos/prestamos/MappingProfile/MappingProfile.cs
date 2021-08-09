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

            #region Others

            CreateMap<PaymentMethod, DropDownListViewModel>()
                .ForMember(d => d.Id, x => x.MapFrom(s => s.Id))
                .ForMember(d => d.Text, x => x.MapFrom(s => s.Description));

            #endregion

            #region Others

            CreateMap<Term, DropDownListViewModel>()
                .ForMember(d => d.Id, x => x.MapFrom(s => s.Id))
                .ForMember(d => d.Text, x => x.MapFrom(s => s.Description));

            #endregion
            #region Others

            CreateMap<StandardEntity, DropDownListViewModel>()
                .ForMember(d => d.Id, x => x.MapFrom(s => s.Id))
                .ForMember(d => d.Text, x => x.MapFrom(s => s.Description));

            #endregion

        }
    }
}
