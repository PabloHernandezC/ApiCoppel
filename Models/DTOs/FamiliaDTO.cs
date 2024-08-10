using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs
{
    public class FamiliaDTO
    {
        public int idFamilia { get; set; }
        public string NombreFamilia { get; set; }
        public int IdClase { get; set; }
        public string NombreClase { get; set; }

    }
}
