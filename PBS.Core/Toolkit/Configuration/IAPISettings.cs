using System;
namespace PBS.Core.Toolkit.Configuration
{
    public interface IAPISettings
    {
        string GetEventServiceUrl();

        string GetMemberServiceUrl();

    }
}
