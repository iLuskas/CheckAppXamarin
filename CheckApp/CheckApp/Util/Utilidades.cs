using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CheckApp.Util
{
    public static class Utilidades
    {
        public static string SerializarJson<T>(T objeto)
        {
            return JsonConvert.SerializeObject(objeto);
        }

        public static T DesserealizarJson<T>(string json)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.NullValueHandling = NullValueHandling.Ignore;

            return JsonConvert.DeserializeObject<T>(json, settings);
        }
        public static async Task<string> RequestByPost(string uri, string bodyJson, WebHeaderCollection headers = null)
        {
            try
            {
                var client = new RestClient(uri);
                var request = new RestRequest(Method.POST);

                if (headers != null)
                    foreach (var key in headers.AllKeys)
                        request.AddHeader(key, headers[key]);

                request.Parameters.Clear();
                request.AddParameter("application/json", bodyJson, ParameterType.RequestBody);

                IRestResponse response = await client.ExecuteAsync(request);
                return response.Content;             
            }
            catch (WebException webex)
            {
                using (Stream responseStream = webex.Response.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(responseStream))
                    {
                      
                        throw;
                    }
                }
            }
            catch (Exception ex)
            {               
                throw;
            }
        }

        public static async Task<string> RequestByGet(string uri, WebHeaderCollection headers = null)
        {
            try
            {
                RestClient client = new RestClient(uri);
                RestRequest request = new RestRequest(Method.GET);

                if (headers != null)
                    foreach (var key in headers.AllKeys)
                        request.AddHeader(key, headers[key]);

                request.Timeout = (int)TimeSpan.FromSeconds(60).TotalMilliseconds;

                IRestResponse response =  await client.ExecuteAsync(request);

                return response.Content;
            }
            catch (WebException webex)
            {
                using (Stream responseStream = webex.Response.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(responseStream))
                    {
                        throw;
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
