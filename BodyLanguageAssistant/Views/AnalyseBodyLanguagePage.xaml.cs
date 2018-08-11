using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Azure.CognitiveServices.Vision.Face.Models;
using Plugin.Media.Abstractions;
using Xamarin.Forms;
using Plugin.Media;
using System;
using BodyLanguageAssistant.ViewModels;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace BodyLanguageAssistant
{
	public partial class AnalyseBodyLanguagePage : ContentPage
	{
		public AnalyseBodyLanguagePage()
		{
			InitializeComponent();
			BindingContext = new AnalyseBodyLanguageViewModel();
			Xamarin.Forms.NavigationPage.SetHasNavigationBar(this, false);

			On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);
		}
	}
}