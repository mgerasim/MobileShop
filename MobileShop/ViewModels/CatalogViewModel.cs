using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using MobileShop.ViewModels.Base;
using ShopFramework.Models;
using Xamarin.Forms;

namespace MobileShop.ViewModels
{
    public class CatalogViewModel : ViewModelBase
    {
        /// <summary>
        /// Корневая категория 
        /// </summary>
        Category _categoryParent = null;

        Category _selectedCategory;

        public Category SelectedCategory
        {
            get 
            {
                return _selectedCategory;
            }
            set 
            {
                _selectedCategory = value;

                RaisePropertyChanged(() => SelectedCategory);
            }
        }

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
                    string parentId = null;

                    if (_categoryParent != null) 
                    {
                        parentId = _categoryParent.Id;
                    }

                    return GlobalSettings.Instance.Shop.Categories.Category.Where(x => x.ParentId == parentId).ToArray();
                }
            }
        }

        public string Title 
        {
            get 
            {
                if (_categoryParent == null)
                {
                    return GlobalSettings.Instance.Shop.Name;
                }
                else
                {
                    return GlobalSettings.Instance.Shop.Categories.Category.FirstOrDefault(x => x.Id == _categoryParent.Id).Text;
                }
            }
        }

        public ICommand SelectCatalogItemCommand => new Command<Category>(SelectCatalogItem);

        /// <summary>
        /// Класс модели представления
        /// </summary>
        public CatalogViewModel(Category categoryParent)
        {
            _categoryParent = categoryParent;
        }

        public override Task InitializeAsync(object parameter)
        {
            _categoryParent = (parameter as Category);


            RaisePropertyChanged(() => Categories);

            RaisePropertyChanged(() => Title);

            return base.InitializeAsync(parameter);
        }

        private void SelectCatalogItem(Category category)
        {
            NavigationService.NavigateToAsync<CatalogViewModel>(category);

        }
    }
}
