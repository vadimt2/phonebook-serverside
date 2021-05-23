using PhoneBookAPI.Core.Entities;

namespace PhoneBookAPI.Infrastructure
{
    public interface IUnitOfWork
    {
        IRepository<Contact> PhoneBookRepo { get; }
    }
}
