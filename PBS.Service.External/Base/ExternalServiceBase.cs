using System;
using System.Threading.Tasks;
using PBS.Core.Toolkit;
using PBS.Toolkit;

namespace PBS.Service.External
{
    public abstract class ExternalServiceBase
    {
        private readonly IPBSClient _client;

        internal abstract string APIUrl { get; }
        internal abstract ServiceResponseTypes ResponseTypes { get; }

        public ExternalServiceBase(IPBSClient client)
        {
            _client = client;
        }

        public async Task<T> GetData<T>(string queryParams, string param1 = "")
        {
            switch (ResponseTypes)
            {
                case ServiceResponseTypes.XML:
                    return await _client.GetXMLResult<T>($"{APIUrl}{queryParams}", param1);
                default:
                    return await _client.GetJsonResult<T>($"{APIUrl}{queryParams}");
            }
        }
    }
}
