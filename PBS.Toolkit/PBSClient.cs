using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;
using PBS.Core.Toolkit;

namespace PBS.Toolkit
{
    public class PBSClient : IPBSClient
    {
        public PBSClient()
        {
        }

        private async Task<T> GetResult<T>(string url, ServiceResponseTypes responseTypes, string xmlRoot = "")
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    switch (responseTypes)
                    {
                        case ServiceResponseTypes.Json:
                            {
                                return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
                            }
                        case ServiceResponseTypes.XML:
                            {
                                var serializer = new XmlSerializer(typeof(T), new XmlRootAttribute(xmlRoot));
                                StringReader stringReader = new StringReader(await response.Content.ReadAsStringAsync());
                                return (T)serializer.Deserialize(stringReader);
                            }
                    }
                }
            }
            return default(T);
        }

        public async Task<T> GetJsonResult<T>(string url)
        {
            return await GetResult<T>(url, ServiceResponseTypes.Json);
        }

        public async Task<T> GetXMLResult<T>(string url, string xmlRoot)
        {
            return await GetResult<T>(url, ServiceResponseTypes.XML, xmlRoot);
        }
    }
}
