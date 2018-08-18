using AppBlogRest.Models.Repositories;
using AppBlogRest.Models.Entities;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using AppBlogRest.Services;
using System.Collections.Generic;

namespace AppBlogRest.ViewModels.CommentViewModels
{
    class CommentsViewModel : BaseViewModel<Comment>
    {
        public ObservableCollection<Comment> Comments { get; set; }
        public Command LoadCommentsCommand { get; set; }
        public Post _post;

        public CommentsViewModel(Post post)
        {
            Title = "Comments";
            Comments = new ObservableCollection<Comment>();
            _post = post;
            LoadCommentsCommand = new Command(async () => await ExecuteLoadCommentsCommand());

        }

        async Task ExecuteLoadCommentsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Comments.Clear();
                CommentRepository commentRepository = new CommentRepository();
                var items = commentRepository.Get(c => c.PostId == _post.Id);
                foreach (var item in items)
                {
                    Comments.Add(item);
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

        public async Task<int> RefreshComments()
        {
            RestService<Comment> restService = new RestService<Comment>();
            List<Comment> comments = await restService.GetAsync($"comments?postId={_post.Id}");
            int adicionados = 0;
            CommentRepository commentRepository = new CommentRepository();

            foreach (Comment comment in comments)
            {
                Comment validaComment = commentRepository.Find(comment.Id);
                if (validaComment == null)
                {
                    commentRepository.Add(comment);
                    adicionados++;
                }
            }
            return adicionados;
        }
    }
}
