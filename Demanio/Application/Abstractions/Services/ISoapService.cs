using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using Models.Entities;

namespace Application.Abstractions.Services
{
    [ServiceContract]
    public interface ISoapService
    {
        [OperationContract]
        DatoDemanio[] GetData();

        [OperationContract]
        DatoDemanio[] GetDataByProvincia(string provincia);
    }
}
