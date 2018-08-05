using System.Threading.Tasks;
using System.Windows.Input;
using MvvmHelpers;
using Xamarin.Forms;
namespace BodyLanguageAssistant
{
	public class AnalyseTextViewModel : BaseViewModel
	{
		private string _textForAnalysis;
		private string _sentimentAnalysisResult;
		private Color _sentimentResultColour;

		public AnalyseTextViewModel()
		{
			AnalyseTextCommand = new Command(async () => await AnalyseText(_textForAnalysis));
		}

		public ICommand AnalyseTextCommand { get; }

		public string TextForAnalysis
		{
			get => _textForAnalysis;
			set => SetProperty(ref _textForAnalysis, value);
		}

		public string SentimentAnalysisResult
		{
			get => _sentimentAnalysisResult;
			set => SetProperty(ref _sentimentAnalysisResult, value);
		}

		public Color SentimentResultColour
		{
			get => SentimentResultColour;
			set => SetProperty(ref _sentimentResultColour, value);
		}

		private async Task AnalyseText(string textForAnalysis)
		{
			var analyser = new TextAnalyser();
			switch (await analyser.AnalyseSentimentAsync(textForAnalysis))
			{
				case Sentiment.Unknown:
					SentimentResultColour = Color.Blue;
					SentimentAnalysisResult = "Hmmm I can't seem to tell how you are feeling!";
					break;
				case Sentiment.Normal:
					SentimentAnalysisResult = "You seem normal to me!";
					break;
				case Sentiment.Positive:
					SentimentResultColour = Color.Gold;
					SentimentAnalysisResult = "Zip-a-dee-doo-dah, zip-a-dee-ay My, oh, my, what a wonderful day ";
					break;
				case Sentiment.Negative:
					SentimentResultColour = Color.Red;
					SentimentAnalysisResult = "Sucks to be you!";
					break;
			}
		}

	}

}
