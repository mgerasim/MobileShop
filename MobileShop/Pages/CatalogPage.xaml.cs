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
        private CategoryViewModel viewMode = null;

        public CatalogPage()
        {
            InitializeComponent();

            viewMode = new CategoryViewModel(null);

            BindingContext = viewMode;
        }

        protected override async void OnAppearing()
        {
            if (GlobalSettings.Instance.Shop == null)
            {
                DataAccessYandexMarket dal = new DataAccessYandexMarket("https://www.tdsammet.ru/index.php?route=feed/yandex_market");
                GlobalSettings.Instance.Shop = (await dal.GetShop()).Shop;

                await viewMode.InitializeAsync();
            }

            base.OnAppearing();
        }
    }
}
