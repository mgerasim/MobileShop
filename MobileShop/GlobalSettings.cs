using System;
using ShopFramework.Models;

namespace MobileShop
{
    public class GlobalSettings
    {
        public Shop Shop { get; set; }

        public static GlobalSettings Instance = new GlobalSettings();

        public GlobalSettings()
        {

        }
    }
}
