using ADN.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADN.Application.Contracts.Persistence
{
    public interface IAdnRepository : IAsyncRepository<Adn>
    {
        Task<Adn> InsertADN(string adn, bool isclon);

        Task<Adn> ValideADN(string adn);
    }
}
