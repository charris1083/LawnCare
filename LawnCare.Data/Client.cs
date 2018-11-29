using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawnCare.Data
{
    class Client
    {
        [Key]
        public int CustomerId { get; set; }

        [Required]
        public Guid ClientId { get; set; }

        [Required]
        public string ClientName { get; set; }

        [Required]
        public string ClientCity { get; set; }

        [Required]
        public string ClientNeeds { get; set; }
    }
}
