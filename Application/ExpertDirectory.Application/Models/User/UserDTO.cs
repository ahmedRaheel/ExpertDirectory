using System;

namespace ExpertDirectory.Application.Models.User
{
    public class UserDTO
    {
        public long Id { get; set; }
        public string UserName { get; set; }
        public string PersonWebUrl { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
