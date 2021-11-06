namespace ExpertDirectory.Domain.Common
{
    public interface IEntityBase<TId> 
    {
        TId Id { get; set; }
    }
}
