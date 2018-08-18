using AppBlogRest.Models.Entities;
using AppBlogRest.ViewModels.UserViewModels;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppBlogRest.Views.UserViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class UsersPage : ContentPage
    {
        UsersViewModel viewModel;
        public UsersPage ()
		{
			InitializeComponent ();
            BindingContext = viewModel = new UsersViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var user = args.SelectedItem as User;
            if (user == null)
                return;

            await Navigation.PushAsync(new UserDetailPage(new UserDetailViewModel(user)));

            // Manually deselect item.
            UsersListView.SelectedItem = null;
        }

        async void Refresh_Clicked(object sender, EventArgs e)
        {
            try
            {
                int adicionados = await viewModel.Refresh();
                viewModel.Users.Clear();
                viewModel.LoadUsersCommand.Execute(null);
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

            if (viewModel.Users.Count == 0)
                viewModel.LoadUsersCommand.Execute(null);
        }
    }
}