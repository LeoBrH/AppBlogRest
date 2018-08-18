using AppBlogRest.ViewModels.PostViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppBlogRest.Views.PostViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PostDetailPage : ContentPage
	{
        PostDetailViewModel viewModel;
        public PostDetailPage(PostDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        async void OnButtonCommentsClicked(object sender, EventArgs args)
        {
            var pageComments = new CommentViews.CommentsPage(viewModel.Post);
            await Navigation.PushAsync(pageComments);
        }
    }
}