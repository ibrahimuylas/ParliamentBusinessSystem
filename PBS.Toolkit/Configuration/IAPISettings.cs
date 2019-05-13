using System;
namespace PBS.Toolkit.Configuration
{
    public interface IAPISettings
    {
        string GetEventServiceUrl();

        string GetMemberServiceUrl();

    }
}
