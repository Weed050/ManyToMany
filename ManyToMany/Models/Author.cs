namespace ManyToMany.Models
{
    public class Author
    {
        public int AuthorID { get; set; }
        public string AuthorName { get; set; }
        public List<Books> Books { get; set; }
        //public List<BooksAndAuthors> BooksAndAuthors { get; set; } = new List<BooksAndAuthors>();
    }
}
