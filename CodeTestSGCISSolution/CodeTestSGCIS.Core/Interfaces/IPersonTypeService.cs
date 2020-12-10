using CodeTestSGCIS.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CodeTestSGCIS.Core.Interfaces
{
    public interface IPersonTypeService
    {
        IEnumerable<TypePerson> GetPersonTypes();

        Task<TypePerson> GetPersonType(int id);

        Task InsertPersonType(TypePerson personType);

        Task<bool> UpdatePersonType(TypePerson personType);

        Task<bool> DeletePersonType(int id);
    }
}