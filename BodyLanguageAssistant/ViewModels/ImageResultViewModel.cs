using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Azure.CognitiveServices.Vision.Face.Models;
using MvvmHelpers;
using Plugin.Media.Abstractions;
using Xamarin.Forms;

namespace BodyLanguageAssistant.ViewModels
{
	public class ImageResultViewModel : BaseViewModel
	{
		StreamImageSource ImageToAnalyse { get; }
		DetectedFace Face { get; }

		public ImageResultViewModel(MediaFile photo, IEnumerable<DetectedFace> faces)
		{
			ImageToAnalyse = (StreamImageSource)ImageSource.FromStream(() => photo.GetStreamWithImageRotatedForExternalStorage());
			imageSource = ImageSource.FromStream(() => photo.GetStreamWithImageRotatedForExternalStorage());
			var emotions = faces.Select(face => GetEmotion(face));

			Description = "Most likely emotion: " + emotions.FirstOrDefault().Key + " with a score of " + emotions.FirstOrDefault().Value.ToString();

		}

		ImageSource imageSource;
		public ImageSource AnalysedPhoto
		{
			get => imageSource;
			set => SetProperty(ref imageSource, value);
		}

		public string Description { get; }


		private KeyValuePair<string, double> GetEmotion(DetectedFace face)
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

			return emotions.OrderByDescending(e => e.Value).First();
		}


	}
}
