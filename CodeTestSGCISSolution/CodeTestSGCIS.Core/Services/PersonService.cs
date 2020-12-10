using CodeTestSGCIS.Core.Entities;
using CodeTestSGCIS.Core.Exceptions;
using CodeTestSGCIS.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CodeTestSGCIS.Core.Services
{
    public class PersonService : IPersonService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PersonService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Person> GetPerson(int id)
        {
            return await _unitOfWork.PersonRepository.GetById(id);
        }

        public IEnumerable<Person> GetPersons()
        {
            return  _unitOfWork.PersonRepository.GetAll();
        }

        public async Task InsertPerson(Person person)
        {
            var personType = await _unitOfWork.PersonTypeRepository.GetById(person.IdTypePerson);
            if(personType == null)
            {
                throw new BusinessException("Type Person doesn't exist");
            }
            await _unitOfWork.PersonRepository.Add(person);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> UpdatePerson(Person person)
        {
            if (person.IdTypePerson != 0)
            {
                var personType = await _unitOfWork.PersonTypeRepository.GetById(person.IdTypePerson);
                if (personType == null)
                {
                    throw new BusinessException("Type Person doesn't exist");
                }
            }
            _unitOfWork.PersonRepository.Update(person);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeletePerson(int id)
        {
            await _unitOfWork.PersonRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
