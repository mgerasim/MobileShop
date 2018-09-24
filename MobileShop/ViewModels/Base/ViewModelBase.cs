using System.Threading.Tasks;
using MobileShop.Services.Navigation;

namespace MobileShop.ViewModels.Base
{
	public abstract class ViewModelBase : ExtendedBindableObject
	{

        protected readonly INavigationService NavigationService;

        bool _isBusy;

		public bool IsBusy
		{
			get
			{
				return _isBusy;
			}

			set
			{
				_isBusy = value;

				RaisePropertyChanged(() => IsBusy);
			}
		}

		protected ViewModelBase()
		{
            NavigationService = new NavigationService();
		}

		public virtual Task InitializeAsync(object parameter)
		{
            return Task.CompletedTask;
		}
	}
}