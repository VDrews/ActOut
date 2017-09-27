using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ActOut.Services;
using Newtonsoft.Json;

namespace ComputerVisionApplication.Services
{
    public class TextAnalyticsService
    {
        /// <summary>
        /// Doc: 
        /// https://westus.dev.cognitive.microsoft.com/docs/services/TextAnalytics.V2.0/operations/56f30ceeeda5650db055a3c9/
        /// </summary>
        private string _detectSentimentUrl = "https://westus.api.cognitive.microsoft.com/text/analytics/v2.0/sentiment";

        private readonly string _key;

        public TextAnalyticsService(string key)
        {
            _key = key;
        }

        /// <summary>
        /// Detects the language of a given text.
        /// Documentation : 
        /// https://westus.dev.cognitive.microsoft.com/docs/services/TextAnalytics.V2.0/operations/56f30ceeeda5650db055a3c7
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public async Task<SentimentResult> DetectSentimentFromTextAsync(string text)
        {
            var httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", _key);

            var stringContent = new StringContent(@"{""documents"": [{""language"": ""es"",""id"": ""1"",""text"" : """ + text + @"""}]}");

            stringContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            try
            {
                var response = await httpClient.PostAsync(_detectSentimentUrl, stringContent);

                var json = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {

                    var sentimentResult = JsonConvert.DeserializeObject<SentimentResult>(json);

                    return sentimentResult;
                }

                throw new Exception(json);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}
