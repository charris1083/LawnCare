﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawnCare.Models
{
    public class ClientListItem
    {
        public int ClientId { get; set; }
        public string ClientName { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
