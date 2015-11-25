using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheHub.Models
{
    interface IToDoRepository
    {
        IEnumerable<Member> GetAll();
        Member GetMemberByID(int memberId);
        void AddMember(Member member);
        void DeleteMember(int memberId);
        void UpdateMember(Member member);
        void Save();
        void Dispose();
    }
}
