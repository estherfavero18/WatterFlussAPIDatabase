using APIDatabase.Models;
using APIDatabase.Models.Context;
using APIDatabase.Repository.Generic;
using APIDatabase.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace APIDatabase.Repository.Implementation
{
    public class SensorNivelRepository :
        GenericRepository<SensorNivelModel>,
        ISensorNivelRepository
    {
        public SensorNivelRepository(SqlServerContext context) : base(context) { }

        public List<SensorNivelModel> FindByRepositorio(int idRepositorio)
        {
            return _context.sensor_nivel
                    .Include(s => s.Reservatorio)
                    .Where(s => s.reservatorioid == idRepositorio).ToList();
        }
    }
}
