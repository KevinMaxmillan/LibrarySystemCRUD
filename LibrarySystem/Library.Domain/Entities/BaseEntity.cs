namespace LibrarySystem.Library.Domain.Entities
{
    // Abstract base class for all entities in the system
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
