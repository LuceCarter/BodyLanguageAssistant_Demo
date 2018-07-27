using System;
using System.Collections.Generic;
using Plugin.Media;
using Plugin.Media.Abstractions;

using Xamarin.Forms;
using System.IO;

namespace BodyLanguageAssistant
{
	public partial class AnalyseBodyLanguagePage : ContentPage
	{
		Image image = new Image();
		public AnalyseBodyLanguagePage()
		{
			InitializeComponent();
		}

		public async void TakeOrPhotoButtonClicked(object sender, EventArgs e)
		{
			await CrossMedia.Current.Initialize();


			if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
			{
				if (!CrossMedia.Current.IsPickPhotoSupported)
				{
					var file = await CrossMedia.Current.PickPhotoAsync(new PickMediaOptions());
					if (file == null)
						return;

					await DisplayAlert("File Location", file.Path, "OK");

					image.Source = ImageSource.FromStream(() =>
					{
						var stream = file.GetStream();
						return stream;
					});

				}
				DisplayAlert("No Camera", "This device does not have a camera available!", "OK");
				return;
			}
		}
	}