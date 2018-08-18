using SQLite;

namespace AppBlogRest.Models.Entities
{
    public class Post
    {
        public int UserId { get; set; }
        [PrimaryKey]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }
}
