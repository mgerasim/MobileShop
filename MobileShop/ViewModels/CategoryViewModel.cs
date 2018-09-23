using System;
using System.Threading.Tasks;
using MobileShop.ViewModels.Base;
using ShopFramework.Models;

namespace MobileShop.ViewModels
{
    public class CategoryViewModel : ViewModelBase
    {
        /// <summary>
        /// Корневая категория 
        /// </summary>
        Category _categoryParent = null;

        public Category[] Categories 
        {
            get
            {
                if (GlobalSettings.Instance.Shop == null)
                {
                    return new Category[] { new Category() };
                }
                else
                {
                    return GlobalSettings.Instance.Shop.Categories.Category.ToArray();
                }
            }
        }

        /// <summary>
        /// Класс модели представления
        /// </summary>
        public CategoryViewModel(Category categoryParent)
        {
        }

        public override Task InitializeAsync()
        {

            return base.InitializeAsync();
        }
    }
}
