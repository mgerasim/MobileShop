using System;
using System.Collections.Generic;
using MobileShop.ViewModels;
using Xamarin.Forms;

namespace MobileShop.Pages
{
    public partial class SplashPage : ContentPage
    {
        SplashViewModel _viewModel = null;

        public SplashPage()
        {
            InitializeComponent();

            _viewModel = new SplashViewModel();

            BindingContext = _viewModel;
        }

        protected override async void OnAppearing()
        {
            await _viewModel.InitializeAsync(null);

            base.OnAppearing();
        }
    }
}
