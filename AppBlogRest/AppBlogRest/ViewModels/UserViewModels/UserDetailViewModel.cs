using AppBlogRest.Models.Entities;

namespace AppBlogRest.ViewModels.UserViewModels
{
    public class UserDetailViewModel : BaseViewModel<User>
    {
        public User User { get; set; }

        public UserDetailViewModel(User user = null)
        {
            Title = user?.Username;
            User = user;
        }
    }
}
