using ADN.Application.Contracts.Persistence;
using ADN.Data.Data;
using ADN.Domain.Entities;
using ADN.Domain.Interfaces.Utilities;
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

        public async Task<Adn> InsertADN(string adn, bool isclon)
        {
            var objADN = _context.Adns.FirstOrDefault(x => x.Adn1 == adn);

            if (objADN == null)
            {
                objADN = new Adn();
                objADN.Adn1 = adn;
                objADN.IsClon = isclon;
                await _context.AddAsync(objADN);
            }

            return objADN;
        }

        public async Task<Adn> ValideADN(string adn)
        {
            var objADN = await Task.FromResult(_context.Adns.FirstOrDefault(x => x.Adn1 == adn));
            return objADN;
        }
    }
}
