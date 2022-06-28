using APIDatabase.Models;
using APIDatabase.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIDatabase.Repository.Interface
{
    public interface IUsuarioRepository : IGenericRepository<UsuarioModel>
    {
        UsuarioModel GetByLogin(string email, string senha);
        UsuarioModel GetByEmail(string email);
        UsuarioModel GetByCpf(string cpf);
    }
}
