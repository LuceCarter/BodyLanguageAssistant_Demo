using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Azure.CognitiveServices.Vision.Face.Models;
using Plugin.Media.Abstractions;
using Xamarin.Forms;
using Plugin.Media.Abstractions;
using Plugin.Media;

namespace BodyLanguageAssistant
{
	public partial class AnalyseBodyLanguagePage : ContentPage
	{


		public AnalyseBodyLanguagePage()
		{
			InitializeComponent();
		}

		public async void TakeOrPhotoButtonClicked(object sender, EventArgs e)
		{
			await CrossMedia.Current.Initialize();

			var options = new StoreCameraMediaOptions { PhotoSize = PhotoSize.Medium };
			var photo = await CrossMedia.Current.TakePhotoAsync(options);

			var photoSource = (StreamImageSource)ImageSource.FromStream(() => photo.GetStreamWithImageRotatedForExternalStorage());
			DetectedFace detectedFace = new DetectedFace();
			EmotionAnalysisResult.Text = "Emotion: " + GetEmotion(face.)

		}

		private string GetEmotion(DetectedFace face)
		{
			var emotions = new Dictionary<string, double>
			{
				{nameof(face.FaceAttributes.Emotion.Anger), face.FaceAttributes.Emotion.Anger},
				{nameof(face.FaceAttributes.Emotion.Contempt), face.FaceAttributes.Emotion.Contempt},
				{nameof(face.FaceAttributes.Emotion.Disgust), face.FaceAttributes.Emotion.Disgust},
				{nameof(face.FaceAttributes.Emotion.Fear), face.FaceAttributes.Emotion.Fear},
				{nameof(face.FaceAttributes.Emotion.Happiness), face.FaceAttributes.Emotion.Happiness},
				{nameof(face.FaceAttributes.Emotion.Neutral), face.FaceAttributes.Emotion.Neutral},
				{nameof(face.FaceAttributes.Emotion.Sadness), face.FaceAttributes.Emotion.Sadness},
				{nameof(face.FaceAttributes.Emotion.Surprise), face.FaceAttributes.Emotion.Surprise},
			};

			return emotions.OrderByDescending(e => e.Value).First().Key;
		}

	}
}