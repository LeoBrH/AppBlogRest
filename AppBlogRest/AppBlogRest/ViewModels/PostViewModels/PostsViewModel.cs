using AppBlogRest.Models.Repositories;
using AppBlogRest.Models.Entities;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using AppBlogRest.Services;
using System.Collections.Generic;

namespace AppBlogRest.ViewModels.PostViewModels
{
    class PostsViewModel : BaseViewModel<Post>
    {
        public ObservableCollection<Post> Posts { get; set; }
        public Command LoadPostsCommand { get; set; }

        public PostsViewModel()
        {
            Title = "Posts";
            Posts = new ObservableCollection<Post>();
            LoadPostsCommand = new Command(async () => await ExecuteLoadPostsCommand());

        }

        async Task ExecuteLoadPostsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Posts.Clear();
                PostRepository postRepository = new PostRepository();
                    var items = postRepository.GetAll();
                    foreach (var item in items)
                    {
                        Posts.Add(item);
                    }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public async Task<int> AddPost()
        {
            RestService<Post> restService = new RestService<Post>();
            Random random = new Random();
            List<Post> posts = await restService.GetAsync("posts", random.Next(0, 100));
            int adicionados = 0;
            PostRepository postRespository = new PostRepository();

            foreach (Post post in posts)
            {
                Post validaPost = postRespository.Find(post.Id);
                if (validaPost == null)
                {
                    UserRepository userRepository = new UserRepository();
                    User user = userRepository.Find(post.UserId);
                    if (user == null)
                    {
                        UserViewModels.UsersViewModel userViewModel = new UserViewModels.UsersViewModel();
                        await userViewModel.ImportUser(post.UserId);
                    }
                    postRespository.Add(post);
                    adicionados++;
                }
            }
            return adicionados;
        }
    }
}
