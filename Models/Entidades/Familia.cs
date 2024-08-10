using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entidades
{
    public class Familia
    {
        [Key]
        public int IdFamilia { get; set; }
        [Required(ErrorMessage = "El nombre es Requerido")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "El nombre debe tener minimo 1 caracter y maximo 50")]
        public string Nombre { get; set; }
        public int IdClase { get; set; }
        [ForeignKey("Clase")]
        public Clase clase { get; set; }

    }
}
