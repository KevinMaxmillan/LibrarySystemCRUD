namespace LibrarySystem.Library.Domain.Entities
{
    public class Book : BaseEntity
    {
        public required String Title { get; set; }
        public required String Author { get; set; }
        public required String Description { get; set; }
    }
}
