using System;
using System.Threading.Tasks;
using MobileShop.Pages;
using MobileShop.ViewModels.Base;
using ShopFramework.Services.DataAccess;
using Xamarin.Forms;

namespace MobileShop.ViewModels
{
    public class SplashViewModel : ViewModelBase
    {
        public SplashViewModel()
        {
        }

        public override async Task InitializeAsync(object parameter)
        {
            await base.InitializeAsync(parameter);

            IsBusy = true;

            var dal = new DataAccessYandexMarket("https://www.tdsammet.ru/index.php?route=feed/yandex_market");

            GlobalSettings.Instance.Shop = (await dal.GetShop()).Shop;


            await NavigationService.NavigateToAsync<CatalogViewModel>();

            await NavigationService.RemoveBackStackAsync();

            IsBusy = false;

            //await Application.Current.MainPage.Navigation.PushAsync(new CatalogPage());
        }
    }
}
