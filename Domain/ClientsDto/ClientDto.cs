using System;
using NodaMoney;

namespace Domain.ClientsDto
{
    public class ClientDto
    {


        public int id { get; set; }
        public string name { get; set; }
        public DateTime since { get; set; }
        public decimal revenue { get; set; }
        
        
    }
}