using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ImovelGo.Web.Helper
{
    /// <summary>
    /// A generic wrapper class to REST API calls
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public static class RestHelper<R, T>
        where R : class
        where T : class
    {
        /// <summary>
        /// For getting the resources from a web api
        /// </summary>
        /// <param name="url">API Url</param>
        /// <returns>A Task with result object of type T</returns>
        public static async Task<R> Get(string url)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            R result = null;
            using (var httpClient = new HttpClient(clientHandler))
            {
                var response = httpClient.GetAsync(new Uri(url)).Result;

                response.EnsureSuccessStatusCode();
                await response.Content.ReadAsStringAsync().ContinueWith((Task<string> x) =>
                {
                    if (x.IsFaulted)
                        throw x.Exception;

                    result = JsonConvert.DeserializeObject<R>(x.Result);
                });
            }

            return result;
        }

        /// <summary>
        /// For creating a new item over a web api using POST
        /// </summary>
        /// <param name="apiUrl">API Url</param>
        /// <param name="postObject">The object to be created</param>
        /// <returns>A Task with created item</returns>
        public static async Task<R> PostRequest(string apiUrl, T postObject)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            R result = null;

            using (var client = new HttpClient(clientHandler))
            {
                string json = JsonConvert.SerializeObject(postObject, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

                using (StringContent content = new StringContent(json, Encoding.UTF8, "application/json"))
                {
                    var response = await client.PostAsync(apiUrl, content).ConfigureAwait(false);

                    //response.EnsureSuccessStatusCode();

                    await response.Content.ReadAsStringAsync().ContinueWith((Task<string> x) =>
                    {
                        if (x.IsFaulted)
                            throw x.Exception;

                        try
                        {
                            result = JsonConvert.DeserializeObject<R>(x.Result);
                        }
                        catch
                        {
                            throw new Exception(x.Result);
                        }

                    });
                }
            }

            return result;
        }

        /// <summary>
        /// For updating an existing item over a web api using PUT
        /// </summary>
        /// <param name="apiUrl">API Url</param>
        /// <param name="putObject">The object to be edited</param>
        public static async Task PutRequest(string apiUrl, T putObject)
        {
            using (var client = new HttpClient())
            {
                string json = JsonConvert.SerializeObject(putObject, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

                using (StringContent content = new StringContent(json, Encoding.UTF8, "application/json"))
                {
                    var response = await client.PutAsync(apiUrl, content).ConfigureAwait(false);
                    response.EnsureSuccessStatusCode();
                }
            }
        }
    }
}
