using Repository.Contracts;
using Repository.EFCore;
using Repository.EFCore.Config;
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
        private readonly Lazy<IRepositoryAboutUs> _repositoryAboutUs;

        public RepositoryManager(RepositoryContext context)
        {
            _context = context;
            _repositoryAboutUs = new Lazy<IRepositoryAboutUs>(() => new RepositoryAboutUs(_context));
            _repositoryUser = new Lazy<IRepositoryUser>(() => new RepositoryUser(_context));
            
        }
        public IRepositoryAboutUs AboutUs => _repositoryAboutUs.Value;
        public IRepositoryUser User => _repositoryUser.Value;

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
