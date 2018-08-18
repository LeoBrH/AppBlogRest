using AppBlogRest.Models.Entities;
using AppBlogRest.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppBlogRest.ViewModels.PostViewModels
{
    public class PostDetailViewModel : BaseViewModel<Post>
    {
        public Post Post { get; set; }
        public User User { get; set; }

        public PostDetailViewModel(Post post)
        {
            UserRepository userRepository = new UserRepository();
            User user = userRepository.Find(post.UserId);
            Title = user?.Name;
            Post = post;
            User = user;
        }
    }
}
