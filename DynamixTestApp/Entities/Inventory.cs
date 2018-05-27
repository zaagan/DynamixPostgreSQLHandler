using System;

namespace DynamixTestApp.Entities
{
    public class Inventory
    {
        public int inventory_id { get; set; }
        public int film_id { get; set; }
        public int store_id { get; set; }
        public DateTime last_update { get; set; }
    }
}
