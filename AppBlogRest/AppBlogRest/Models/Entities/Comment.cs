using SQLite;

namespace AppBlogRest.Models.Entities
{
    public class Comment
    {
        public int PostId { get; set; }
        [PrimaryKey]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Body { get; set; }
    }
}
