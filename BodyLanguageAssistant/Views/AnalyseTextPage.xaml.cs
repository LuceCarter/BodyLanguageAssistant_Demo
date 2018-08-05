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
			BindingContext = new AnalyseTextViewModel();
		}

		public async void AnalyseTextButtonClicked(object sender, EventArgs e)
		{
			var analyser = new TextAnalyser();
			switch (await analyser.AnalyseSentimentAsync(TextForAnalysisEntry.Text))
			{
				case Sentiment.Unknown:
					SentimentAnalysisResultLabel.TextColor = Color.Blue;
					SentimentAnalysisResultLabel.Text = "Hmmm I can't seem to tell how you are feeling!";
					break;
				case Sentiment.Normal:
					SentimentAnalysisResultLabel.Text = "You seem normal to me!";
					break;
				case Sentiment.Positive:
					SentimentAnalysisResultLabel.TextColor = Color.Gold;
					SentimentAnalysisResultLabel.Text = "Zip-a-dee-doo-dah, zip-a-dee-ay My, oh, my, what a wonderful day ";
					break;
				case Sentiment.Negative:
					SentimentAnalysisResultLabel.TextColor = Color.Red;
					SentimentAnalysisResultLabel.Text = "Sucks to be you!";
					break;
			}
		}
	}
}
