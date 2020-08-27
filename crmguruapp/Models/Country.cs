﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace crmguruapp.Models
{
    public class Country
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("numericCode")]
        public string Code { get; set; }

        [JsonProperty("capital")]
        public string Capital { get; set; }

        [JsonProperty("area")]
        public double Area { get; set; }

        [JsonProperty("population")]
        public int Population { get; set; }

        [JsonProperty("region")]
        public string Region { get; set; }

        public string GetInfo => $"Имя: {Name} | Код: {Code} | Столица: {Capital} | Площадь: {Area} | " +
                $"Население: {Population} | Регион: {Region}";
    }
}
