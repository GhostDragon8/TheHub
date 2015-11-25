using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TheHub.Models
{
    public class ToDoRepository : IToDoRepository
    {
        private MemberDbContext context;

        public ToDoRepository(MemberDbContext context)
        {
            this.context = context;
        }

        public void AddMember(Member member)
        {
            context.Member.Add(member);
        }

        public void DeleteMember(int memberId)
        {
            Member member = context.Member.Find(memberId);
            context.Member.Remove(member);
        }

        public IEnumerable<Member> GetAll()
        {
            return context.Member.ToList();
        }

        public Member GetMemberByID(string memberId)
        {
            return context.Member.Find(memberId);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void UpdateMember(Member member)
        {
            context.Entry(member).State = EntityState.Modified;
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if(!this.disposed)
            {
                if(disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public Member GetMemberByID(int memberId)
        {
            throw new NotImplementedException();
        }
    }
}