using Repository.Contracts;
using Repository.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _context;
        
        private readonly Lazy<IRepositoryUser> _repositoryUser;
        private readonly Lazy<IRepositoryUser> _repositoryRoom;

        public RepositoryManager(RepositoryContext context)
        {
            _context = context;
           
            _repositoryUser = new Lazy<IRepositoryUser>(() => new RepositoryUser(_context));
            _repositoryRoom = new Lazy<IRepositoryUser>(() => new RepositoryUser(_context));

        }
        public IRepositoryUser User => _repositoryUser.Value;
        public IRepositoryUser Room => _repositoryRoom.Value;

        public void Save()
        {
            _context.SaveChanges();
        }

        public Task SaveAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}
