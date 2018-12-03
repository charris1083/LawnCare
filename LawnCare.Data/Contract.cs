using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawnCare.Data
{
    public class Contract
    {
        [Key]
        public int ContractId { get; set; }
        public Guid ContractGuid { get; set; }
        public int MyProperty { get; set; }
        public int ClientId { get; set; }
        public int MowerId { get; set; }

        public virtual Client Client { get; set; }
        public virtual Mower Mower { get; set; }
    }
}
