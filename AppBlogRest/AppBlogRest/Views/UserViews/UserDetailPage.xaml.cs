using AppBlogRest.ViewModels.UserViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppBlogRest.Views.UserViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class UserDetailPage : ContentPage
    {
        UserDetailViewModel viewModel;
        public UserDetailPage(UserDetailViewModel viewModel)
		{
			InitializeComponent ();
            BindingContext = this.viewModel = viewModel;
        }

        public UserDetailPage()
        {
            InitializeComponent();


            viewModel = new UserDetailViewModel();
            BindingContext = viewModel;
        }
    }
}