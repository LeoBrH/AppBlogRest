using AppBlogRest.Models.Entities;
using AppBlogRest.ViewModels.PostViewModels;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppBlogRest.Views.PostViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PostsPage : ContentPage
    {
        PostsViewModel viewModel;

        public PostsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new PostsViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var post = args.SelectedItem as Post;
            if (post == null)
                return;

            await Navigation.PushAsync(new PostDetailPage(new PostDetailViewModel(post)));

            PostsListView.SelectedItem = null;
        }

        async void AddPost_Clicked(object sender, EventArgs e)
        {
            try
            {
                int adicionados = await viewModel.AddPost();

                viewModel.Posts.Clear();
                viewModel.LoadPostsCommand.Execute(null);
                await DisplayAlert("Concluído", $"Itens adicionados: {adicionados}", "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", $"Ocorreu um erro ao atualizar os dados. Detalhes: {ex.Message}", "OK");
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Posts.Count == 0)
                viewModel.LoadPostsCommand.Execute(null);
        }
    }
}