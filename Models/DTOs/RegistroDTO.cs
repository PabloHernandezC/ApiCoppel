using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs
{
    public class RegistroDTO
    {
        [Required(ErrorMessage = "Nombre de Usuario es Requerido")]
        public string userName { get; set; }
        [Required(ErrorMessage = "Password es Requerido")]
        [StringLength(10, MinimumLength = 4, ErrorMessage = "El Nombre de usuario debe de tener entre 4 y 10 Caracteres")]
        public string password { get; set; }
    }
}
