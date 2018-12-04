using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawnCare.Models
{
    public class ContractCreate
    {
        public string ClientName { get; set; }
        public string MowerName { get; set; }
        public string Mowersrevice { get; set; }
        public decimal MowerRate { get; set; }
        public string mowerCity { get; set; }
        public string ClientCity { get; set; }
    }
}
