﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MobileShop.Pages;
using MobileShop.ViewModels;
using MobileShop.ViewModels.Base;
using Xamarin.Forms;

namespace MobileShop.Services.Navigation
{
	public class NavigationService : INavigationService
	{
		public ViewModelBase PreviousPageViewModel
		{
			get
			{
				var mainPage = Application.Current.MainPage as CustomNavigationPage;
				var viewModel = mainPage.Navigation.NavigationStack[mainPage.Navigation.NavigationStack.Count - 2].BindingContext;
				return viewModel as ViewModelBase;
			}
		}

		public NavigationService()
		{

		}

		public Task InitializeAsync()
		{
			return NavigateToAsync<SplashViewModel>();
		}

		public Task NavigateToAsync<TViewModel>() where TViewModel : ViewModelBase
		{
			return InternalNavigateToAsync(typeof(TViewModel), null);
		}

		public Task NavigateToAsync<TViewModel>(object parameter) where TViewModel : ViewModelBase
		{
			return InternalNavigateToAsync(typeof(TViewModel), parameter);
		}

		public Task RemoveLastFromBackStackAsync()
		{
			var mainPage = Application.Current.MainPage as CustomNavigationPage;

			if (mainPage != null)
			{
				mainPage.Navigation.RemovePage(
					mainPage.Navigation.NavigationStack[mainPage.Navigation.NavigationStack.Count - 2]);
			}

			return Task.FromResult(true);
		}

		public Task RemoveBackStackAsync()
		{
			var mainPage = Application.Current.MainPage as CustomNavigationPage;

			if (mainPage != null)
			{
				for (int i = 0; i < mainPage.Navigation.NavigationStack.Count - 1; i++)
				{
					var page = mainPage.Navigation.NavigationStack[i];
					mainPage.Navigation.RemovePage(page);
				}
			}

			return Task.FromResult(true);
		}

		private async Task InternalNavigateToAsync(Type viewModelType, object parameter)
		{
			Page page = CreatePage(viewModelType, parameter);

			if (page is SplashPage)
			{
				Application.Current.MainPage = new CustomNavigationPage(page);
			}
			else
			{
				var navigationPage = Application.Current.MainPage as CustomNavigationPage;
				if (navigationPage != null)
				{
					await navigationPage.PushAsync(page);
				}
				else
				{
					Application.Current.MainPage = new CustomNavigationPage(page);
				}
			}

			await (page.BindingContext as ViewModelBase).InitializeAsync(parameter);
		}

		private Type GetPageTypeForViewModel(Type viewModelType)
		{
			var viewName = viewModelType.FullName.Replace("ViewModel", "Page");
			var viewModelAssemblyName = viewModelType.GetTypeInfo().Assembly.FullName;
			var viewAssemblyName = string.Format(CultureInfo.InvariantCulture, "{0}, {1}", viewName, viewModelAssemblyName);
			var viewType = Type.GetType(viewAssemblyName);
			return viewType;
		}

		private Page CreatePage(Type viewModelType, object parameter)
		{
			Type pageType = GetPageTypeForViewModel(viewModelType);
			if (pageType == null)
			{
				throw new Exception($"Cannot locate page type for {viewModelType}");
			}

			Page page = Activator.CreateInstance(pageType) as Page;
			return page;
		}
	}
}
