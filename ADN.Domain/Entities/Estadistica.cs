using System;
using System.Collections.Generic;

namespace ADN.Domain.Entities
{
    public partial class Estadistica
    {
        public int Id { get; set; }
        public string Llave { get; set; }
        public long Valor { get; set; }
    }
}
