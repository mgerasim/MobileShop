using System;
using ShopFramework.Models;

namespace ShopFramework.Services.DataAccess
{
    /// <summary>
    /// Интерфейс получения данных
    /// </summary>
    public interface IDataAccess
    {
        Shop GetShop();
    }
}
