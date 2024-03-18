using Entities.ModelsDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IAboutUsService
    {
        IEnumerable<AboutUsDto> GetAllAboutUs();
        AboutUsDto GetByIdAboutUs(int id);
        AboutUsDto CreateAboutUs(AboutUsDto aboutUsDto);
        void UpdateAboutUs(AboutUsDto aboutUsDto);
        void DeleteAboutUs(int id);
    }
}
