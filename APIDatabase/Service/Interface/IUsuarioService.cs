using APIDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIDatabase.Service.Interface
{
    public interface IUsuarioService
    {
        List<UsuarioModel> GetAll();
        UsuarioModel GetById(int id);
        UsuarioModel GetByLogin(string email, string senha);
        UsuarioModel GetByEmail(string email);
        UsuarioModel GetByCpf(string cpf);
        UsuarioModel Post(UsuarioModel item);
        UsuarioModel Put(UsuarioModel item);
        void Delete(int id);
    }
}