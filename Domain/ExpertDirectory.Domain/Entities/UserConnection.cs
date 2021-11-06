using ExpertDirectory.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpertDirectory.Domain.Entities
{
    /// <summary>
    ///     UserConnections
    /// </summary>
    public class UserConnection : EntityBase<long>
    {
        /// <summary>
        ///     UserId
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        ///     User
        /// </summary>
        public virtual User User { get; set; } 

        /// <summary>
        ///     ConnectionId
        /// </summary>
        public long ConnectionId { get; set; }
        /// <summary>
        ///     Connections
        /// </summary>
        public virtual User Connection { get; set; }
    }
}
