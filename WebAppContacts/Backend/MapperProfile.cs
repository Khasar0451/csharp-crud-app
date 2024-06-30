using AutoMapper;
using WebAppContacts.Server.DTO;
using WebAppContacts.Server.Entities;

namespace WebAppContacts.Server
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Contact, ContactDTO>();
            CreateMap<ContactDTO, Contact>();

            CreateMap<ContactAddDTO, Contact>().ReverseMap();   //maps both way 

            CreateMap<Contact, ContactListDTO>();
        }
    }
}
