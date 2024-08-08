using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IUnidadTrabajo : IDisposable
    {
        IArticuloRepositorio Articulo { get; }
        IClaseRepositorio Clase { get; }
        IDepartamentoRepositorio Departamento { get; }
        IFamiliaRepositorio Familia { get; }

        Task Guardar();
    }
}
