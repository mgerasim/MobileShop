using System;
using ShopFramework.Models;

namespace ShopFramework.Services.DataAccess
{
    /// <summary>
    /// Получение данных
    /// </summary>
    public class DataAccess : IDataAccess
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public DataAccess()
        {
        }

        /// <summary>
        /// Возвращает объект описания магазина
        /// </summary>
        /// <returns>The shop.</returns>
        public Shop GetShop()
        {
            throw new NotImplementedException();
        }
    }
}
