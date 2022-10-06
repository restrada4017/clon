using ADN.Data.Data;
using ADN.Domain.Entities;
using ADN.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADN.Data.Repositories
{

    public class AdnRepository : BaseRepository<Adn>, IAdnRepository
    {
        public AdnRepository(DbADNContext context) : base(context)
        {
        }

        public async Task<bool> InsertADN(string adn,bool isclon)
        {
            var objADN = await Task.FromResult(_entities.FirstOrDefault(x => x.Adn1 == adn));

            if (objADN == null)
            {
                objADN = new Adn();
                objADN.Adn1 = adn;
                objADN.IsClon = isclon;
                _entities.Add(objADN);
                return true;
            }

            return false;
        }
    }
}
