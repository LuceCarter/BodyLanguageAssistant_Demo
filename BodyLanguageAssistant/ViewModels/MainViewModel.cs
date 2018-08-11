using System;
using Xamarin.Forms;
using MvvmHelpers;
using System.Windows.Input;
namespace BodyLanguageAssistant.ViewModels
{
	public class MainViewModel : BaseViewModel
	{
		private readonly INavigation navigation;

		public MainViewModel(INavigation navigation)
		{
			this.navigation = navigation;
		}

		public ICommand AnalyseTextButtonClicked
		{
			get
			{
				return new Command(() =>
				{
					navigation.PushModalAsync(new AnalyseTextPage());
				});

			}

		}

		public ICommand AnalyseBodyLanguageButtonClicked
		{
			get
			{
				return new Command(() =>
				{
					navigation.PushModalAsync(new AnalyseBodyLanguagePage());
				});
			}
		}
	}
}
