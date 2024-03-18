using AutoMapper;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Repository.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.EFCore
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IAboutUsService> _about;
        private readonly Lazy<IUserService> _user;

        public ServiceManager(IRepositoryManager repository, IMapper mapper, UserManager<User> userManager, IConfiguration configuration)
        {
            _about = new Lazy<IAboutUsService>(() => new AboutUsService(repository, mapper));
            _user = new Lazy<IUserService>(() => new UserService(repository, mapper));
        }

        public IAboutUsService AboutUsService => _about.Value;
        public IUserService UserService => _user.Value;
    }
}
