using FN.Store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FN.Store.Domain.Contracts.Repositories
{
    public interface IUsuarioRepository: IRepository<Usuario>
    {
        Usuario GetByEmail(string email);

    }
}
