using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADN.Domain.CustomEntities
{
    public class ConfigurationAdn
    {
        public string AdnSequence { get; set; }
        public int Min { get; set; }
        public List<Search> Search { get; set; }
    }
     

    public class Search
    {
        public string Sequence { get; set; }
    }
}
