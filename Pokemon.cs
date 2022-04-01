using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PokeDexWithJSON
{
    class Pokemon
    {
        public string name { get; set; }
        public string category { get; set; }
        public string height { get; set; }
        public string weight { get; set; }
        public string move { get; set; }
        public string weaknesses { get; set; }
        public string gender { get; set; }
        public string hp { get; set; }
        public string desc { get; set; }
        public string picture { get; set; }
    }
}
