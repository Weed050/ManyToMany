namespace ManyToMany.Models
{
    public class Books
    {
        public int BooksID { get; set; }
        public int BookName { get; set; }
        public List<BooksAndAuthors> BooksAndAuthors { get; set; } = new List<BooksAndAuthors>();
    }
}
