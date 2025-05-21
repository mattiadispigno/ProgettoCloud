
using Application.Abstractions.Services;
using Models.Entities;  
using Newtonsoft.Json;

namespace Application.Services  
{  
    public class DemanioService : IDemanioService
    {  
        public async Task<DatoDemanio[]> DaiDati()  
        {  
            var httpClient = new HttpClient();  

            string BaseUri = "https://dati.agenziademanio.it/odrepos/contopatrimoniale/patrimonio-2024-categoria-provincia.json";  

            var response = await httpClient.GetAsync(BaseUri);  
            var contents = await response.Content.ReadAsStringAsync();  

            DatoDemanio[] datiDemanio = JsonConvert.DeserializeObject<DatoDemanio[]>(contents);  
            return datiDemanio;
        }  

        public async Task<DatoDemanio[]> RicercaPerProvincia(string Provincia)  
        {  
            DatoDemanio[] datiDemanio = await DaiDati();  

            return datiDemanio.Where(s => s.Provincia.ToUpper().Contains(Provincia.ToUpper())).ToArray();
        }
    }  
}  
