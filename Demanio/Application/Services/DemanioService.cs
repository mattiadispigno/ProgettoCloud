
using Application.Abstractions.Services;
using Microsoft.AspNetCore.Http.Timeouts;
using Models.Entities;  
using Newtonsoft.Json;

namespace Application.Services  
{  
    public class DemanioService : IDemanioService
    {  
        public async Task<DatoDemanio[]> GetData()  
        {
            var httpClient = new HttpClient();

            string BaseUri = "https://dati.agenziademanio.it/odrepos/contopatrimoniale/patrimonio-2024-categoria-provincia.json";  

            var response = await httpClient.GetAsync(BaseUri);  
            var contents = await response.Content.ReadAsStringAsync();  

            DatoDemanio[] datiDemanio = JsonConvert.DeserializeObject<DatoDemanio[]>(contents);
            return datiDemanio;
        }

        public async Task<DatoDemanioTotal[]> GetDataWithTotal()
        {
            DatoDemanio[] datiDemanio = await GetData();
            return datiDemanio
                .GroupBy(d => d.Provincia)
                .Select(g => new DatoDemanioTotal
                {
                    NumeroFabbricati = g.Sum(d => d.NumeroFabbricati),
                    ValoreFabbricatieuro = g.Sum(d => d.ValoreFabbricatieuro),
                    NumeroTerreni = g.Sum(d => d.NumeroTerreni),
                    ValoreTerrenieuro = g.Sum(d => d.ValoreTerrenieuro),
                    NumeroTotale = g.Sum(d => d.NumeroTotale),
                    Regione = g.First().Regione,
                    Provincia = g.First().Provincia,

                    TotaleSpesaProvincia = g.Sum(d => d.ValoreTotaleeuro)
                })
                .OrderByDescending(p => p.TotaleSpesaProvincia)
                .ToArray();
        }

        public async Task<DatoDemanio[]> RicercaPerProvincia(string Provincia)
        {
            DatoDemanio[] datiDemanio = await GetData();  

            return datiDemanio.Where(s => s.Provincia.ToUpper().Contains(Provincia.ToUpper())).ToArray();
        }

        public async Task<DatoDemanio[]> RicercaPerRegione(string Regione)
        {
            DatoDemanio[] datiDemanio = await GetData();  

            return datiDemanio.Where(s => s.Regione.ToUpper().Contains(Regione.ToUpper())).ToArray();

        }
    }  
}  
