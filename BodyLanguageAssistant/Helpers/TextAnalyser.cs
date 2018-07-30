using System;
using Microsoft.Azure.CognitiveServices.Language.TextAnalytics;
using Microsoft.Azure.CognitiveServices.Language.TextAnalytics.Models;
using System.Collections.Generic;
using Microsoft.Rest;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Linq;

namespace BodyLanguageAssistant
{
	public class TextAnalyser
	{
		const string sentimentBaseURL = " https://westeurope.api.cognitive.microsoft.com";
		const string sentimentAPIKey = "b8222a8fcc96454ba813aaeae9d32c13";

		readonly HttpClient httpClient = new HttpClient
		{
			BaseAddress = new Uri(sentimentBaseURL),
			Timeout = TimeSpan.FromSeconds(60),
		};

		public async Task<Sentiment> AnalyseSentimentAsync(string textToAnalyse)
		{
			var requestJson = "{ \"documents\": [ { \"language\": \"en\", \"id\": \"1\", \"text\": \"" + textToAnalyse + "\" } ] }";
			HttpResponseMessage responseMessage;
			using (var requestContent = new StringContent(requestJson))
			{
				requestContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
				requestContent.Headers.Add("Ocp-Apim-Subscription-Key", sentimentAPIKey);

				responseMessage = await httpClient.PostAsync("text/analytics/v2.0/sentiment", requestContent).ConfigureAwait(false);
			}

			if (!responseMessage.IsSuccessStatusCode)
			{
				return Sentiment.Unknown;
			}

			var responseJson = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
			var recognitionResult = JsonConvert.DeserializeObject<SentimentRecognitionResult>(responseJson);

			if (recognitionResult.Errors.Count > 0)
			{
				return Sentiment.Unknown;
			}

			var score = recognitionResult.Documents.FirstOrDefault()?.Score;

			if (score <= 0.3)
			{
				return Sentiment.Negative;
			}

			if (score <= 0.6)
			{
				return Sentiment.Normal;
			}

			return Sentiment.Positive;
		}
	}

	public class SentimentRecognitionResult
	{

		public IList<Document> Documents { get; set; }
		public IList<object> Errors { get; set; }

		public class Document
		{
			public double Score { get; set; }
			public string Id { get; set; }
		}

	}
}
