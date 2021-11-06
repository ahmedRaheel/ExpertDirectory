using System.Collections.Generic;

namespace ExpertDirectory.Application.Models.User
{
    public class MemberProfileDTO 
    {
        public MemberProfileDTO() 
        {
            Friends = new List<MemberFriendDTO>();
            Headings = new List<WebHeadingsDTO>();
        }
        public long Id { get; set; }
        public string UserName { get; set; }
        public string PersonWebUrl { get; set; }
        public List<MemberFriendDTO> Friends { get; set; }
        public List<WebHeadingsDTO> Headings { get; set; }
    }
}
