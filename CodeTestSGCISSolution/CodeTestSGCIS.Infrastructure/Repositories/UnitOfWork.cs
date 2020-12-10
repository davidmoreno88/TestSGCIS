using CodeTestSGCIS.Core.Entities;
using CodeTestSGCIS.Core.Interfaces;
using CodeTestSGCIS.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CodeTestSGCIS.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CodeTestSGCISContext _context;
        private readonly IRepository<Person> _personRepository;
        private readonly IRepository<TypePerson> _typePersonRepository;

        public UnitOfWork(CodeTestSGCISContext context)
        {
            _context = context;
        }
        public IRepository<Person> PersonRepository => _personRepository ?? new BaseRepository<Person>(_context);

        public IRepository<TypePerson> PersonTypeRepository => _typePersonRepository ?? new BaseRepository<TypePerson>(_context);

        public void Dispose()
        {
            if(_context != null)
            {
                _context.Dispose();
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
