using System;

namespace DynamixTestApp.Entities
{
    public class City
    {
        public int city_id { get; set; }

        public string city { get; set; }

        public int country_id { get; set; }

        public DateTime last_update { get; set; }
    }
}
