using System;
using System.Threading.Tasks;
using PBS.Domain.External;

namespace PBS.Core.Service.External
{
    public interface IMemberService
    {
        Task<Member> GetMemberByIdAsync(int id);

    }
}
