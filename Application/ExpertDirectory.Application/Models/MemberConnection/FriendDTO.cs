using System.Collections.Generic;

namespace ExpertDirectory.Application.Models.MemberConnection
{
    public class FriendDTO
    {
        public FriendDTO()
        {
            Friends = new List<FriendDTO>();
        }
        #region Properties
        public long Id { get; set; }
        public string UserName { get; set; }
        public List<FriendDTO> Friends { get; set; } 
        #endregion
    }
}