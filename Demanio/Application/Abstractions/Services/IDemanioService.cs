using Models.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions.Services
{
    public interface IDemanioService
    {
        public Task<DatoDemanio[]> GetData();

        public Task<DatoDemanio[]> RicercaPerProvincia(string Provincia);

        public Task<DatoDemanioTotal[]> GetDataWithTotal();
        public Task<DatoDemanio[]> RicercaPerRegione(string Regione);
    }
}
