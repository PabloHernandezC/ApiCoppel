using Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Servicios.Interfaces
{
    public interface ITokenServicio
    {
        string CrearToken(Usuario usuario);
    }
}
