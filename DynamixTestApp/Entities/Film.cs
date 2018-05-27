using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamixTestApp.Entities
{
    public class Film
    {
        public long film_id { get; set; }
        public string title { get; set; }

        public string description { get; set; }

        public int release_year { get; set; }

        public int language_id { get; set; }
        public int rental_duration { get; set; }

        public decimal rental_rate { get; set; }

        public int length { get; set; }

        public decimal replacement_cost { get; set; }

        public string rating { get; set; }

        public DateTime last_update { get; set; }

        public string[] special_features { get; set; }

        public object fulltext { get; set; }

    }
}
