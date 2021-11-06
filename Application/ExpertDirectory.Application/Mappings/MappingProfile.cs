using AutoMapper;
using ExpertDirectory.Application.Models.MemberConnection;
using ExpertDirectory.Application.Models.User;
using ExpertDirectory.Domain.Entities;
using MemberListDTO = ExpertDirectory.Application.Models.User.MemberListDTO;

namespace ExpertDirectory.Application.Mappings
{
    public class MappingProfile : Profile
    {     
        public MappingProfile() 
        {            
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<UserHeadings, WebHeadingsDTO>().ReverseMap();
            CreateMap<UserHeadings, MemberSearchDTO>()
                                   .ForMember(m => m.Id, b => b.MapFrom(u => u.User.Id))
                                   .ForMember(m => m.UserName, b => b.MapFrom(u => u.User.UserName));               
         
            CreateMap<UserConnection, MemberFriendDTO>()
                       .ForMember(o => o.Id, b => b.MapFrom(z => z.Connection.Id))
                      .ForMember(o => o.UserName, b => b.MapFrom(z => z.Connection.UserName))
                      .ForMember(o => o.PersonWebUrl, b => b.MapFrom(z => z.Connection.PersonWebUrl));
           
            CreateMap<User, MemberListDTO>()
                      .ForMember(o => o.Id, b => b.MapFrom(z => z.Id))
                      .ForMember(o => o.UserName, b => b.MapFrom(z=> z.UserName))
                      .ForMember(o => o.PersonWebUrl, b => b.MapFrom(z => z.PersonWebUrl))
                      .ForMember(o => o.FriendCounts, b => b.MapFrom(user => 
                                   user.UserConnections.Count + user.FriendConnections.Count));
            CreateMap<User, MemberProfileDTO>()
                         .ForMember(m => m.Id, u => u.MapFrom(x => x.Id))
                         .ForMember(m => m.UserName, u => u.MapFrom(x => x.UserName))
                         .ForMember(m => m.PersonWebUrl, u => u.MapFrom(x => x.PersonWebUrl));          
                         
        }
    }
}
