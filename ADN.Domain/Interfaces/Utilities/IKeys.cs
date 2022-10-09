using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADN.Domain.Interfaces.Utilities
{
    public interface IKeys
    {
        Task<string> GetValueByKey(string key);
        bool IsUseKey();

    }
}
