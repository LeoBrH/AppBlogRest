using AppBlogRest.Models.Repositories;
using AppBlogRest.Models.Entities;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using AppBlogRest.Services;
using System.Collections.Generic;

namespace AppBlogRest.ViewModels.UserViewModels
{
    class UsersViewModel : BaseViewModel<User>
    {
        public ObservableCollection<User> Users { get; set; }
        public Command LoadUsersCommand { get; set; }

        public UsersViewModel()
        {
            Title = "Users";
            Users = new ObservableCollection<User>();
            LoadUsersCommand = new Command(async () => await ExecuteLoadUsersCommand());

        }

        async Task ExecuteLoadUsersCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Users.Clear();
                UserRepository userRepository = new UserRepository();
                var items = userRepository.GetAll();
                foreach (var item in items)
                {
                    Users.Add(item);
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

        public async Task<int> Refresh()
        {
            RestService<UserJson> restService = new RestService<UserJson>();

            List<UserJson> users = await restService.GetAsync("users");
            int adicionados = 0;
            UserRepository userRespository = new UserRepository();

            foreach (UserJson userJson in users)
            {
                User validaUser = userRespository.Find(userJson.Id);
                if (validaUser == null)
                {
                    userRespository.Add(JsonToUser(userJson));
                    adicionados++;
                }
            }
            return adicionados;
        }

        public async Task ImportUser(int userId)
        {
            RestService<UserJson> restService = new RestService<UserJson>();

            List<UserJson> users = await restService.GetAsync("users", userId);
            UserRepository userRespository = new UserRepository();

            foreach (UserJson userJson in users)
            {
                User validaUser = userRespository.Find(userJson.Id);
                if (validaUser == null)
                {
                    userRespository.Add(JsonToUser(userJson));
                }
            }
        }

        private User JsonToUser(UserJson userJson)
        {
            User user = new User();
            user.Id = userJson.Id;
            user.Name = userJson.Name;
            user.Username = userJson.Username;
            user.Email = userJson.Email;
            user.Address_Street = userJson.Address.Street;
            user.Address_Suite = userJson.Address.Suite;
            user.Address_City = userJson.Address.City;
            user.Address_Zipcode = userJson.Address.Zipcode;
            user.Address_Geo_Lat = userJson.Address.Geo.Lat;
            user.Address_Geo_Lng = userJson.Address.Geo.Lng;
            user.Phone = userJson.Phone;
            user.Website = userJson.Website;
            user.Company_Name = userJson.Company.Name;
            user.Company_CatchPhrase = userJson.Company.CatchPhrase;
            user.Company_Bs = userJson.Company.Bs;
            return user;
        }
    }
}
