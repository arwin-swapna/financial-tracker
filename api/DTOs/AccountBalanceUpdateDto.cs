using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs
{
    public class AccountBalanceUpdateDto
    {
        public decimal Balance { get; set; }
        public decimal Available { get; set; } 
    }
}