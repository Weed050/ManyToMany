namespace ManyToMany.Models
{
    public class Books
    {
        public int BooksID { get; set; }
        public string BookName { get; set; }
        public List<Author> Author { get; set; }
        //public List<BooksAndAuthors> BooksAndAuthors { get; set; } = new List<BooksAndAuthors>();
    }
}
