using System;
using AtvidadeModuloTres;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AtvidadeModuloTres.Models
{
    public class ClienteCadastro
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int CPF { get; set; }
        [Required]
        public string Endereco { get; set; }
    }
}
