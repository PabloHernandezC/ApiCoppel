using Models.DTOs;
using Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IArticuloRepositorio : IRepositorioGenerico<Articulo>
    {
        //void Actualizar(Articulo articulo);

        public Task<List<ArticuloDTO>> ObtenerLista();
        public Task<IEnumerable<ArticuloDTO>> ObtenerSKU(int id);
        public Task<int> AgregarArticulo(Articulo articulo);
        public Task<int> Actualizar(Articulo articulo);
        public Task<int> Eliminar(int id);
    }
}
