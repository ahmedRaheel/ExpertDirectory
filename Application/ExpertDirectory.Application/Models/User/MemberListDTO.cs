namespace ExpertDirectory.Application.Models.User
{
    public class MemberListDTO 
    {
        public long Id { get; set; }
        public string UserName { get; set; }
        public string PersonWebUrl { get; set; }
        public int FriendCounts { get; set; }
    }
}
