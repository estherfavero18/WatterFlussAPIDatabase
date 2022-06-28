using APIDatabase.Models;
using APIDatabase.Models.Context;
using APIDatabase.Repository.Generic;
using APIDatabase.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace APIDatabase.Repository.Implementation
{
    public class SensorVazaoRepository :
        GenericRepository<SensorVazaoModel>,
        ISensorVazaoRepository
    {
        public SensorVazaoRepository(SqlServerContext context) : base(context) { }
        public List<SensorVazaoModel> FindByRepositorio(int idRepositorio)
        {
            return _context.sensor_vazao
                    .Where(s => s.reservatorioid == idRepositorio).ToList();
        }
    }
}
