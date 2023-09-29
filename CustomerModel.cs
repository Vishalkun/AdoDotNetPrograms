using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADOnetDemo
{
    internal class CustomerModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string city { get; set; }
        public long phone { get; set; }
        public int salary { get; set; }

        public DateTime start_date { get; set; }
    }
}
