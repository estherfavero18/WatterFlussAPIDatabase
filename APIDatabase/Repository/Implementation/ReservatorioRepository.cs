using APIDatabase.Models;
using APIDatabase.Models.Context;
using APIDatabase.Repository.Generic;
using APIDatabase.Repository.Interface;
using System.Linq;

namespace APIDatabase.Repository.Implementation
{
    public class ReservatorioRepository : 
        GenericRepository<ReservatorioModel>,
        IReservatorioRepository
    {
        public ReservatorioRepository(SqlServerContext context) : base(context) { }

        public ReservatorioModel FindByUsuario(string email)
        {
            return _context.reservatorio
                    .Where(r => r.usuario.email == email).FirstOrDefault();
        }
    }
}
