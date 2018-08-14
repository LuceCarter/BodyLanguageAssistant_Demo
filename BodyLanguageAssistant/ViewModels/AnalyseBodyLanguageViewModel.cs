using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Azure.CognitiveServices.Vision;
using Microsoft.Azure.CognitiveServices.Vision.Face;
using Microsoft.Azure.CognitiveServices.Vision.Face.Models;
using Plugin.Media.Abstractions;
using Xamarin.Forms;
using System.Linq.Expressions;
using BodyLanguageAssistant.Views;
using MvvmHelpers;
using BodyLanguageAssistant.Helpers;

namespace BodyLanguageAssistant.ViewModels
{
	public class AnalyseBodyLanguageViewModel : BaseViewModel
	{
		FaceClient faceFinder;

		public AnalyseBodyLanguageViewModel()
		{
			TakePhotoCommand = new Command(async () => await TakePhotoAsync());
			faceFinder = new FaceClient(new ApiKeyServiceClientCredentials(AzureKeys.FaceApiKey));
			faceFinder.Endpoint = AzureKeys.BaseUrl;

		}
		MediaFile photo;
		StreamImageSource imageSource;
		public StreamImageSource ImageForAnalysis
		{
			get => imageSource;
			set => SetProperty(ref imageSource, value);
		}

		bool isBusy;
		public bool IsBusy
		{
			get => isBusy;
			set => SetProperty(ref isBusy, value);
		}


		public ICommand TakePhotoCommand { get; }
		private async Task TakePhotoAsync()
		{
			try
			{
				IsBusy = true;
				photo = await Plugin.Media.CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions());
				ImageForAnalysis = (StreamImageSource)ImageSource.FromStream(() => photo.GetStream());

				using (var stream = photo.GetStreamWithImageRotatedForExternalStorage())
				{
					var faceOperations = new FaceOperations(faceFinder);
					var faceAttributes = Enum.GetValues(typeof(FaceAttributeType)).OfType<FaceAttributeType>().ToList();
					var faces = await faceOperations.DetectWithStreamAsync(stream, true, true, faceAttributes);

					if (faces.Any())
					{

						await Application.Current.MainPage.Navigation.PushModalAsync(new ImageResultPage { BindingContext = new ImageResultViewModel(photo, faces) });
					}
					else
					{
						await Application.Current.MainPage.DisplayAlert("Is anybody there?!", "No faces were found, are you a robot?", "OK");
					}
				}
			}
			catch (Exception e)
			{
				await Application.Current.MainPage.DisplayAlert("Error!", e.Message, "OK");
			}
			finally
			{
				IsBusy = false;
			}
		}


	}
}
