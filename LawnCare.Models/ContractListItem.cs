using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawnCare.Models
{
    public class ContractListItem
    {
        public int ContractId { get; set; }
        public int ClientId { get; set; }
        public int MowerId { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
