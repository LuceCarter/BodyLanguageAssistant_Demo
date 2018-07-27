using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BodyLanguageAssistant
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

		public void AnalyseTextButtonClicked(object sender, EventArgs e)
		{
			Navigation.PushModalAsync(new AnalyseTextPage());
		}

		public void AnalyseBodyLanguageButtonClicked(object sender, EventArgs e)
		{
			Navigation.PushModalAsync(new NavigationPage(new AnalyseBodyLanguagePage()));
		}
	}
}
