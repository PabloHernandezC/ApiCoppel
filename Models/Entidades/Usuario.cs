using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entidades
{
    public class Usuario
    {
        [Key]
        public int idUsuario { get; set; }
        public string userName { get; set; }
        public byte[] passwordHash { get; set; }
        public byte[] passwordSalt { get; set; }
    }
}
