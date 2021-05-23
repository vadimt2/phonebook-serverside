using PhoneBookAPI.Core.Entities;
using PhoneBookAPI.DAL.Repositories;
using PhoneBookAPI.Infrastructure;

namespace PhoneBookAPI.DAL
{
    public class UnitOfWork : IUnitOfWork

    {
        private readonly DataContext _context;
        private IRepository<Contact> _phoneBookRepo;

        public UnitOfWork(DataContext appContextDB)
        {
            _context = appContextDB;
        }

        public IRepository<Contact> PhoneBookRepo
        {
            get
            {
                if (_phoneBookRepo == null)
                    _phoneBookRepo = new Repository<Contact>(_context);
                return _phoneBookRepo;
            }
        }

    }
}

