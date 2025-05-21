using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class DatoDemanio
    {
        public int NumeroTerreni { get; set; }

        [JsonProperty("ValoreTotale (euro)")]
        public long ValoreTotaleeuro { get; set; }
        public int NumeroTotale { get; set; }
        public string Categoria { get; set; }
        public string Regione { get; set; }

        [JsonProperty("ValoreFabbricati (euro)")]
        public long ValoreFabbricatieuro { get; set; }
        public int NumeroFabbricati { get; set; }

        [JsonProperty("ValoreTerreni (euro)")]
        public long ValoreTerrenieuro { get; set; }
        public string Provincia { get; set; }
    }
}
