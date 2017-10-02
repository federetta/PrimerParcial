using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace TestParcial.UI.Process
{

    public abstract class ProcessComponent
    {

        protected static T HttpGet<T>(string path, Dictionary<string, object> parameters, string mediaType)
        {
            UriBuilder builder = new UriBuilder
            {
                Path = path,
                Query = string.Join("&", parameters.Where(p => p.Value != null)
                    .Select(p => string.Format("{0}={1}",
                        HttpUtility.UrlEncode(p.Key),
                        HttpUtility.UrlEncode(p.Value.ToString()))))
            };

            return HttpGet<T>(builder.Uri.PathAndQuery, mediaType);
        }


        protected static T HttpGet<T>(string path, List<object> values, string mediaType)
        {
            string query = string.Empty;
            string pathAndQuery = path.EndsWith("/") ? path : path += "/";

            if (values != null && values.Count > 0)
                query = string.Join("/", values.ToArray());

            if (!string.IsNullOrWhiteSpace(query))
                pathAndQuery += query;

            return HttpGet<T>(pathAndQuery, mediaType);
        }


        private static T HttpGet<T>(string pathAndQuery, string mediaType)
        {
            T result = default(T);

            // Execute the Http call.
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["serviceUrl"]);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(mediaType));

                var response = client.GetAsync(pathAndQuery).Result;
                response.EnsureSuccessStatusCode();

                result = response.Content.ReadAsAsync<T>().Result;
            }

            return result;
        }

        public static T HttpPost<T>(string path, T value, string mediaType)
        {

            var pathAndQuery = path.EndsWith("/") ? path : path + "/";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["serviceUrl"]);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(mediaType));
                var response = client.PostAsJsonAsync(pathAndQuery, value).Result;
                response.EnsureSuccessStatusCode();
                return value;

            }

        }
    }
}
