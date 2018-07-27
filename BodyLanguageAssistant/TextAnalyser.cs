using System;
using Microsoft.Azure.CognitiveServices.Language.TextAnalytics;
using Microsoft.Azure.CognitiveServices.Language.TextAnalytics.Models;
using System.Collections.Generic;
using Microsoft.Rest;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace BodyLanguageAssistant
{
	public class TextAnalyser
	{
		public TextAnalyser()
		{
			//ITextAnalyticsClient client = new TextAnalyticsClient(new ApiKeyServiceClientCredentials());

		}
	}

	class ApiKeyServiceClientCredentials : ServiceClientCredentials
	{
		public override Task ProcessHttpRequestAsync(HttpRequestMessage request, CancellationToken cancellationToken)
		{
			request.Headers.Add("Ocp-Apim-Subscription-Key", "b8222a8fcc96454ba813aaeae9d32c13");
			return base.ProcessHttpRequestAsync(request, cancellationToken);
		}
	}
}
