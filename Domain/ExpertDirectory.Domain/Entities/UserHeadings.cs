using ExpertDirectory.Domain.Common;

namespace ExpertDirectory.Domain.Entities
{
    /// <summary>
    ///   UserHeadings
    /// </summary>
    public class UserHeadings : EntityBase<long>
    {
        /// <summary>
        ///      HeadingTitle
        /// </summary>
        public string HeadingTitle { get; set; }
        /// <summary>
        ///     UserId
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        ///     User
        /// </summary>
        public virtual User User { get; set; }        
    }
}
