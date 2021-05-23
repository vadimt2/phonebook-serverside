using PhoneBookAPI.Core.Entities;
using PhoneBookAPI.Infrastructure;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhoneBookAPI.Services
{
    public class PhoneBookService : IPhoneBookService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PhoneBookService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Contact>> Get()
        {
            return await _unitOfWork.PhoneBookRepo.GetAllAsyn();
        }

        public async Task<Contact> Get(int id)
        {
            return await _unitOfWork.PhoneBookRepo.GetAsync(id);
        }

        public async Task<Contact> Add(Contact contact)
        {
            return await _unitOfWork.PhoneBookRepo.AddAsyn(contact);
        }

        public async Task<Contact> Update(int id, Contact contact)
        {
            return await _unitOfWork.PhoneBookRepo.UpdateAsyn(contact, id);
        }

        public async Task<int> Delete(Contact contact)
        {
            return await _unitOfWork.PhoneBookRepo.DeleteAsyn(contact);
        }
    }
}
