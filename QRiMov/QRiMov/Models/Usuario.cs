using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QRiMov.Models
{
    [Table("Usuarios")]
    public class Usuario
    {
        [Key]
        public int INT_ID_USR { get; set; }
        [Required]
        public string STR_NOME_USR { get; set; }
        [Required]
        public string STR_LOGIN_USR { get; set; }
        [Required]
        public string STR_SENHA_USR { get; set; }
    }
}
