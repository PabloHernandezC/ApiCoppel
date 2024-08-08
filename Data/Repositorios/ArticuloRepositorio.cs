using Data.Interfaces;
using Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositorios
{
    public class ArticuloRepositorio : Repositorio<Articulo>, IArticuloRepositorio
    {
        private readonly AppDBContext _db;

        public ArticuloRepositorio(AppDBContext dbContext) : base(dbContext)
        {
            _db = dbContext;
        }

        public void Actualizar(Articulo producto)
        {
            var productoDB = _db.Articulos.FirstOrDefault(e => e.Sku == producto.Sku);
            if (productoDB != null)
            {
                productoDB.Article = producto.Article;
                productoDB.Marca = producto.Marca;
                productoDB.Modelo = producto.Modelo;
                productoDB.IdDepartamento = producto.IdDepartamento;
                productoDB.IdClase = producto.IdClase;
                productoDB.IdFamilia = producto.IdFamilia;
                productoDB.Stock = producto.Stock;
                productoDB.Cantidad = producto.Cantidad;
                productoDB.Descontinuado = producto.Descontinuado;
                _db.SaveChanges();
            }
        }
    }
}
