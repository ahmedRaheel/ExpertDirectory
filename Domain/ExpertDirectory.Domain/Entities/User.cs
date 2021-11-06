using ExpertDirectory.Domain.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpertDirectory.Domain.Entities
{
    /// <summary>
    ///     User
    /// </summary>
    public class User  : EntityBase<long>
    {
        public User()
        {
            UserConnections = new HashSet<UserConnection>();
            UserHeadings = new HashSet<UserHeadings>();
            FriendConnections = new HashSet<UserConnection>();
        }

        /// <summary>
        ///     UserName
        /// </summary>
        [StringLength(256)]
        public string UserName { get; set; }

        /// <summary>
        ///     PersonWebUrl
        /// </summary>
        [StringLength(512)]
        public string PersonWebUrl { get; set; }

        /// <summary>
        ///  UserConnections
        /// </summary>
        [InverseProperty("User")]
        public virtual ICollection<UserConnection> UserConnections { get; set; }
        /// <summary>
        ///  UserConnections
        /// </summary>
        [InverseProperty("Connection")]
        public virtual ICollection<UserConnection> FriendConnections { get; set; }

        /// <summary>
        ///    UserHeadings
        /// </summary>
        public virtual ICollection<UserHeadings> UserHeadings { get; set; }
    }
}
