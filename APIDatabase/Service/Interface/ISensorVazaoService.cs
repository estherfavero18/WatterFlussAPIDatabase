using APIDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIDatabase.Service.Interface
{
    public interface ISensorVazaoService
    {
        List<SensorVazaoModel> GetAll();
        List<SensorVazaoModel> GetByRepositorio(int idRepositorio);
        SensorVazaoModel GetByRepositorioUltimaMedicao(int idRepositorio);
        SensorVazaoModel GetById(int id);
        SensorVazaoModel Post(SensorVazaoModel item);
        void Delete(int id);
    }
}
