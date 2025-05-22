using Newtonsoft.Json;

namespace Models.Entities
{
    public class DatoDemanioTotal
    {
        public int NumeroTerreni { get; set; }
        public int NumeroTotale { get; set; }
        public string Regione { get; set; }

        [JsonProperty("ValoreFabbricati (euro)")]
        public long ValoreFabbricatieuro { get; set; }
        public int NumeroFabbricati { get; set; }

        [JsonProperty("ValoreTerreni (euro)")]
        public long ValoreTerrenieuro { get; set; }
        public string Provincia { get; set; }
        public long TotaleSpesaProvincia { get; set; }
    }
}