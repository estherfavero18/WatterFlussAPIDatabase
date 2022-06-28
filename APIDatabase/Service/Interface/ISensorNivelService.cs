using APIDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIDatabase.Service.Interface
{
    public interface ISensorNivelService
    {
        List<SensorNivelModel> GetAll();
        List<SensorNivelModel> GetByRepositorio(int idRepositorio);
        SensorNivelModel GetByRepositorioUltimaMedicao(int idRepositorio);
        SensorNivelModel GetById(int id);
        SensorNivelModel Post(SensorNivelModel item);
        void Delete(int id);
    }
}
