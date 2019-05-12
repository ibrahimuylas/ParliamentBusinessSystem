using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PBS.Core.Service.External;
using PBS.Core.Toolkit;
using PBS.Core.Toolkit.Configuration;
using PBS.Domain.External;
using PBS.Toolkit;

namespace PBS.Service.External
{
    public class MemberService : ExternalServiceBase, IMemberService
    {
        private readonly IAPISettings _settings;

        internal override ServiceResponseTypes ResponseTypes => ServiceResponseTypes.XML;

        internal override string APIUrl => _settings.GetMemberServiceUrl();

        public MemberService(IAPISettings settings, IPBSClient client) : base(client)
        {
            _settings = settings;
        }

        public async Task<Member> GetMemberByIdAsync(int id)
        {
            List<Member> result = await GetData<List<Member>>($"id={id}", "Members");

            return result != null && result.Count() > 0 ? result[0] : new Member();
        }
    }
}
