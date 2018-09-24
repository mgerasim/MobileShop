using System;
using System.Collections.Generic;
using MobileShop.ViewModels;
using ShopFramework.Services.DataAccess;
using Xamarin.Forms;

namespace MobileShop.Pages
{
    public partial class CatalogPage : ContentPage
    {
        /// <summary>
        /// Класс модели представления
        /// </summary>
        private CatalogViewModel viewModel = null;

        public CatalogPage()
        {
            InitializeComponent();

            viewModel = new CatalogViewModel(null);

            BindingContext = viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}
