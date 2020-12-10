using CodeTestSGCIS.Core.Entities;
using System;
using System.Threading.Tasks;

namespace CodeTestSGCIS.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Person> PersonRepository { get; }

        IRepository<TypePerson> PersonTypeRepository { get; }

        void SaveChanges();

        Task SaveChangesAsync();
    }
}
