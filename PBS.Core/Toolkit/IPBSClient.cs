using System;
using System.Threading.Tasks;

namespace PBS.Core.Toolkit
{
    public interface IPBSClient
    {
        Task<T> GetJsonResult<T>(string url);

        Task<T> GetXMLResult<T>(string url, string xmlRoot);
    }
}
