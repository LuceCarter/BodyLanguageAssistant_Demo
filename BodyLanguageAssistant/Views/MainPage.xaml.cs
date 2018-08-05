using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using BodyLanguageAssistant.ViewModels;

namespace BodyLanguageAssistant
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
			BindingContext = new MainViewModel(Navigation);
		}

	}
}
