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
    public class EstadisticaRepository : BaseRepository<Estadistica>, IEstadisticaRepository
    {
        public EstadisticaRepository(DbADNContext context) : base(context)
        {
        }
    }
}
