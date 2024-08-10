using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs
{
    public class ClaseDTO
    {
        public int IdClase { get; set; }
        [Required(ErrorMessage = "El nombre es Requerido")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "El nombre debe tener minimo 1 caracter y maximo 50")]
        public string NombreClase { get; set; }
        public int IdDepartamento { get; set; }
        public string NombreDepartamento { get; set; }
    }
}
