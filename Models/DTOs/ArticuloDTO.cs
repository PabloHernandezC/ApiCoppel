using Models.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs
{
    public class ArticuloDTO
    {
        public int IdArticulo { get; set; }
        public int Sku { get; set; }
        [Required(ErrorMessage = "El Nombre del Articulo es Requerido")]
        [StringLength(15, MinimumLength = 1, ErrorMessage = "El nombre del Articulo debe tener minimo 1 caracter y maximo 15")]
        public string Article { get; set; }
        [Required(ErrorMessage = "El Nombre de la Marca es Requerido")]
        [StringLength(15, MinimumLength = 1, ErrorMessage = "El nombre de la Marca debe tener minimo 1 caracter y maximo 15")]
        public string Marca { get; set; }
        [Required(ErrorMessage = "El Nombre del Modelo es Requerido")]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "El nombre del Modelo debe tener minimo 1 caracter y maximo 20")]
        public string Modelo { get; set; }
        public int IdDepartamento { get; set; }
        public string NombreDepartamento { get; set; }
        public int IdClase { get; set; }
        public string NombreClase { get; set; }
        public int IdFamilia { get; set; }
        public string NombreFamilia { get; set; }
        public DateTime FechaAlta { get; set; }
        [Required(ErrorMessage = "EL Stack es Requerido")]
        public int Stock { get; set; }
        [Required(ErrorMessage = "EL Cantidad es Requerido")]
        public int Cantidad { get; set; }
        public int Descontinuado { get; set; }
        public DateTime FechaBaja { get; set; }

    }
}
