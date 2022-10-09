using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADN.Domain.CustomEntities;
using ADN.Domain.Interfaces.Utilities;
using Library.KeyVault.Ideact;
using Microsoft.Extensions.Options;

namespace AISC.Utilities.Keys
{

    public class AzureKeyvault : IKeys
    {

        private readonly KeyVaultAdn _KeyVaultAISC;
        private bool _isUseKey = false;

        public AzureKeyvault(IOptions<KeyVaultAdn> options)
        {
            _KeyVaultAISC = options.Value;
            if(!string.IsNullOrEmpty(_KeyVaultAISC.KvUri))
            {
                SecretKeyVaultFacade.SetConfiguration(_KeyVaultAISC.KvUri, _KeyVaultAISC.TenantId, _KeyVaultAISC.ClientId, _KeyVaultAISC.ClientSecret);
            }
            
            _isUseKey = !string.IsNullOrEmpty(_KeyVaultAISC.KvUri);
        }

        public Task<string> GetValueByKey(string key)
        {
            string valuestr = string.Empty;
            valuestr = SecretKeyVaultFacade.GetSecret(key).Value;
            return Task.FromResult(valuestr);
        }

        public bool IsUseKey()
        {
            return _isUseKey;
        }
    }
}
