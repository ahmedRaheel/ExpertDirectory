using ExpertDirectory.Application.Models.User;
using System.Collections.Generic;

namespace ExpertDirectory.Application.Models.MemberConnection
{
    public class MemberSearchDTO
    {
        public MemberSearchDTO()
        {
            Members = new List<FriendDTO>();              
        }
        public long Id { get; set; }
        public string UserName { get; set; }         
        public List<FriendDTO> Members { get; set; }          
    }
}
