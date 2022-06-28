using APIDatabase.Models;
using APIDatabase.Repository.Generic;
using System.Collections.Generic;

namespace APIDatabase.Repository.Interface
{
    public interface ISensorVazaoRepository : IGenericRepository<SensorVazaoModel>
    {
        List<SensorVazaoModel> FindByRepositorio(int idRepositorio);
    }
}
