using System;
using Domain.ClientsDto;
using NodaMoney;

namespace Domain.Clients
{
    public class Client
    {
        public int id { get; set; }
        public string name { get; set; }
        public DateTime since { get; set; }
        public Money revenue { get; set; }


        public Client(ClientDto clientDto)
        {
            this.id = clientDto.id;
            this.name = clientDto.name;
            this.since = clientDto.since;
            this.revenue = new Money(clientDto.revenue, "EUR");
        }

        public Client(){}
    }
}