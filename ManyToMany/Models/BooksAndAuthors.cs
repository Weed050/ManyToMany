namespace ManyToMany.Models
{
    public class BooksAndAuthors
    {
        public Books Books { get; set; }
        public int BooksID { get; set; }
        public Author Author { get; set; }
        public int AuthorID { get; set; }
        public DateTime AddingTime { get; set; }
    }
}
