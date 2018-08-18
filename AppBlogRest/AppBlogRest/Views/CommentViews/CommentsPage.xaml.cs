using AppBlogRest.Models.Entities;
using AppBlogRest.ViewModels.CommentViewModels;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppBlogRest.Views.CommentViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CommentsPage : ContentPage
    {
        CommentsViewModel viewModel;
        public CommentsPage (Post post)
		{
			InitializeComponent ();
            Title = post?.Title;
            BindingContext = viewModel = new CommentsViewModel(post);
        }

        async void Refresh_Clicked(object sender, EventArgs e)
        {
            try
            {
                int adicionados = await viewModel.RefreshComments();

                viewModel.Comments.Clear();
                viewModel.LoadCommentsCommand.Execute(null);
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

            if (viewModel.Comments.Count == 0)
                viewModel.LoadCommentsCommand.Execute(null);
        }
    }
}