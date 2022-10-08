using ADN.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADN.Domain.Interfaces.Repositories
{
    public interface IAdnRepository : IRepository<Adn>
    {
        Task<Adn> InsertADN(string adn, bool isclon);

        Task<Adn> ValideADN(string adn);
    }
}
