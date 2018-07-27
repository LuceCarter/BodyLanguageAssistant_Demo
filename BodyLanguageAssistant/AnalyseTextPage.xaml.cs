using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace BodyLanguageAssistant
{
	public partial class AnalyseTextPage : ContentPage
	{
		public AnalyseTextPage()
		{
			InitializeComponent();
		}

		public void AnalyseTextButtonClicked(object sender, EventArgs e)
		{
			Console.WriteLine(TextForAnalysisEntry.Text);
		}
	}
}
