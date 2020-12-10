using CodeTestSGCIS.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CodeTestSGCIS.Core.Interfaces
{
    public interface IPersonService
    {
        IEnumerable<Person> GetPersons();

        Task<Person> GetPerson(int id);

        Task InsertPerson(Person person);

        Task<bool> UpdatePerson(Person person);

        Task<bool> DeletePerson(int id);
    }
}