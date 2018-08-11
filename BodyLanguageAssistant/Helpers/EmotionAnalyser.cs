using System;
using Microsoft.Azure.CognitiveServices.Vision.Face;
using System.Threading.Tasks;
using Plugin.Media.Abstractions;
using System.Linq;
namespace BodyLanguageAssistant
{
	public class EmotionAnalyser
	{
		const string emotionBaseURL = "https://southcentralus.api.cognitive.microsoft.com/";
		const string emotionAPIKey = "b43fb634e01946c5947ee5ab1d876d24";
		FaceClient faceClient = new FaceClient(credentials: new ApiKeyServiceClientCredentials(emotionAPIKey))
		{
			//BaseUri = new Uri(emotionAPIKey)
		};

		//public async Task<Emotions> AnalyseEmotionAsync(MediaFile photo)
		//{
		//	var faces = faceClient.Face.DetectWithStreamAsync(photo.GetStream());
		//	var emotion = faces.Result.FirstOrDefault().FaceAttributes.Emotion;
		//}

		public EmotionAnalyser()
		{
		}
	}
}
