using System.Windows.Input;
namespace BodyLanguageAssistant
{
	internal class AnalyseTextViewModel
	{
		public AnalyseTextViewModel()
		{
		}

		public async ICommand AnalyseTextButtonClicked
		{
			get => Ana
			}
	}

	private async void AnalyseText()
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