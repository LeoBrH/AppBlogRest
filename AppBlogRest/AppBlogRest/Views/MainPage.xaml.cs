﻿using AppBlogRest.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppBlogRest.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : MasterDetailPage
    {
        Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();
        public MainPage()
        {
            InitializeComponent();

            MasterBehavior = MasterBehavior.Popover;

            /*MenuPages.Add((int)MenuItemType.Users, (NavigationPage)Detail);
            MenuPages.Add((int)MenuItemType.Posts, (NavigationPage)Detail);*/
        }

        public async Task NavigateFromMenu(int id)
        {
            if (!MenuPages.ContainsKey(id))
            {
                switch (id)
                {
                    case (int)MenuItemType.Users:
                        MenuPages.Add(id, new NavigationPage(new UserViews.UsersPage()));
                        break;
                    case (int)MenuItemType.Posts:
                        MenuPages.Add(id, new NavigationPage(new PostViews.PostsPage()));
                        break;
                }
            }

            var newPage = MenuPages[id];

            if (newPage != null && Detail != newPage)
            {
                Detail = newPage;

                if (Device.RuntimePlatform == Device.Android)
                    await Task.Delay(100);

                IsPresented = false;
            }
        }
    }
}