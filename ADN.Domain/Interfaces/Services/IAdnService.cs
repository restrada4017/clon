using ADN.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADN.Domain.Interfaces.Services
{
    public interface IAdnService : IService<Adn>
    {
        Task<bool> IsClon(string[] matrix);
    }
}
