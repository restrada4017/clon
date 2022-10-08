using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADN.Domain.Interfaces.Utilities
{
    public interface ICache
    {
        Task<byte[]> Get(string key);
        Task Set(string key, byte[] value);
    }
}
