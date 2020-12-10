using CodeTestSGCIS.Core.Entities;
using CodeTestSGCIS.Core.Exceptions;
using CodeTestSGCIS.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CodeTestSGCIS.Core.Services
{
    public class PersonTypeService : IPersonTypeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PersonTypeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<TypePerson> GetPersonType(int id)
        {
            return await _unitOfWork.PersonTypeRepository.GetById(id);
        }

        public IEnumerable<TypePerson> GetPersonTypes()
        {
            return  _unitOfWork.PersonTypeRepository.GetAll();
        }

        public async Task InsertPersonType(TypePerson personType)
        {
            await _unitOfWork.PersonTypeRepository.Add(personType);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> UpdatePersonType(TypePerson personType)
        {
            _unitOfWork.PersonTypeRepository.Update(personType);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeletePersonType(int id)
        {
            await _unitOfWork.PersonTypeRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
