using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using BodyLanguageAssistant.ViewModels;

namespace BodyLanguageAssistant
{
	public partial class AnalyseTextPage : ContentPage
	{
		public AnalyseTextPage()
		{
			InitializeComponent();
			BindingContext = new AnalyseTextViewModel();
		}
	}
}
