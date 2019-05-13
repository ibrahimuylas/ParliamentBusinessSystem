using System;
using Microsoft.Extensions.Configuration;

namespace PBS.Toolkit.Configuration
{
    public class APISettings : IAPISettings
    {
        private readonly IConfiguration _configuration;

        public APISettings(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetEventServiceUrl() => _configuration["externalServices:event"];

        public string GetMemberServiceUrl() => _configuration["externalServices:member"];
    }
}
