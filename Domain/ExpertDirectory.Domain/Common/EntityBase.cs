using System;
using System.ComponentModel.DataAnnotations;

namespace ExpertDirectory.Domain.Common
{
    /// <summary>
    ///     EntityBase
    /// </summary>
    /// <typeparam name="TId"></typeparam>
    public class EntityBase<TId> : IEntityBase<TId>
    {
        #region Properties
        public TId Id { get;  set; }

        [StringLength(256)]
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }

        [StringLength(256)]
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        #endregion

        #region Constructor
        public EntityBase()
        {

        }
        #endregion
        #region Method Override
        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is EntityBase<TId>))
                return false;

            if (ReferenceEquals(this, obj))
                return true;

            if (GetType() != obj.GetType())
                return false;
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static bool operator ==(EntityBase<TId> left, EntityBase<TId> right)
        {
            if (Equals(left, null))
                return Equals(right, null) ? true : false;
            else
                return left.Equals(right);
        }

        public static bool operator !=(EntityBase<TId> left, EntityBase<TId> right)
        {
            return !(left == right);
        } 
        #endregion
    }
}
