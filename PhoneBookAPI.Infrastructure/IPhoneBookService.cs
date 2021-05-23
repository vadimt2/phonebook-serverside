using PhoneBookAPI.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhoneBookAPI.Infrastructure
{
    public interface IPhoneBookService
    {
        Task<int> Delete(Contact contact);
        Task<IEnumerable<Contact>> Get();
        Task<Contact> Get(int id);
        Task<Contact> Add(Contact contact);
        Task<Contact> Update(int id, Contact contact);
    }
}