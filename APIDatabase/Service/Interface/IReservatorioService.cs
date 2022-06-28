using APIDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIDatabase.Service.Interface
{
    public interface IReservatorioService
    {
        List<ReservatorioModel> GetAll();
        ReservatorioModel GetById(int id);
        ReservatorioModel GetByUsuario(string email);
        ReservatorioModel Post(ReservatorioModel item);
        ReservatorioModel Put(ReservatorioModel item);
        void Delete(int id);
    }
}