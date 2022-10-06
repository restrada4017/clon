using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTest
{
    public class Status
    {
        public int Id { get; set; }
        public bool IsSuccess { get; set; }
        public bool IsError { get; set; }
        public string Error { get; set; }
        public double TotalSeg { get; set; }

    }
}
