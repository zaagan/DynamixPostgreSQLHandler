using System;

namespace DynamixTestApp.Entities
{
    public class Customer
    {
        public long  customer_id { get; set; }
        public int store_id { get; set; }

        public string first_name { get; set; }

        public string  last_name { get; set; }

        public string email { get; set; }

        public int address_id { get; set; }

        public bool activebool { get; set; }

        public DateTime create_date { get; set; }

        public DateTime last_update { get; set; }

        public int active { get; set; }

    }
}
