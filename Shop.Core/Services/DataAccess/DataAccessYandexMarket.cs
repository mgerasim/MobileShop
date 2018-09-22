using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using ShopFramework.Models;

namespace ShopFramework.Services.DataAccess
{
    /// <summary>
    /// Получает данные на основе ссылки на Yandex
    /// </summary>
    public class DataAccessYandexMarket
    {
        /// <summary>
        /// Строка на Яндекс Маркет
        /// </summary>
        private readonly string _feedYandexMarket;

        /// <summary>
        /// Исходная информация
        /// </summary>
        public string Raw { get; protected set; } = null;

        /// <summary>
        /// Инициализирует исходную информацию подгрузкой данных
        /// </summary>
        public async Task InitAsync()
        {
            var request = WebRequest.Create(new Uri(_feedYandexMarket)) as HttpWebRequest;
            request.Method = "GET";
            WebResponse responseObject = await Task<WebResponse>.Factory.FromAsync(request.BeginGetResponse, request.EndGetResponse, request);
            var responseStream = responseObject.GetResponseStream();
            var sr = new StreamReader(responseStream);
            Raw = await sr.ReadToEndAsync();

        }
         
        public DataAccessYandexMarket(string feedYandexMarket)
        {
            _feedYandexMarket = feedYandexMarket;
        }

        public async Task<Yml_catalog> GetShop()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            var serializer = new XmlSerializer(typeof(Yml_catalog));


            var request = WebRequest.Create(new Uri(_feedYandexMarket)) as HttpWebRequest;
            request.Method = "GET";
            WebResponse responseObject = await Task<WebResponse>.Factory.FromAsync(request.BeginGetResponse, request.EndGetResponse, request);
            var responseStream = responseObject.GetResponseStream();

            Yml_catalog shop;

            using (var sr = new StreamReader(responseStream, Encoding.GetEncoding(1251)))
            {
                shop = (Yml_catalog)serializer.Deserialize(sr);

            }

            //await sr.ReadToEndAsync();



            return shop;


        }
    }
}
