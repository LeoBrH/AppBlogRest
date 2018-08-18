namespace AppBlogRest.Models
{
    public enum MenuItemType
    {
        Users,
        Posts
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
