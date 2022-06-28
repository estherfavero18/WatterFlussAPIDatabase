using APIDatabase.Models;
using APIDatabase.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIDatabase.Repository.Interface
{
    public interface ISensorNivelRepository : IGenericRepository<SensorNivelModel>
    {
        List<SensorNivelModel> FindByRepositorio(int idRepositorio);
    }
}
