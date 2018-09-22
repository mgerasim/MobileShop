using System;
using System.Threading.Tasks;
using ShopFramework.Services.DataAccess;
using Xunit;

namespace MobileShop.FunctionalTests.Services
{
    public class DataAccessTest
    {
        const string feed = "https://www.tdsammet.ru/index.php?route=feed/yandex_market";

        [Fact]
        public async Task DataAccessYandexMarket_NotNull()
        {
            var dataAccessYandexMarket = new DataAccessYandexMarket(feed);

            await dataAccessYandexMarket.InitAsync();

            var shop = await dataAccessYandexMarket.GetShop();

            Assert.Equal("Магазин ООО «Саммет»", shop.Shop.Name);
        }
    }
}
