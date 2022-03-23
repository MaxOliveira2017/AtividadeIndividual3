using System;
using AtvidadeModuloTres;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AtvidadeModuloTres.Models
{
    public class ClienteReserva
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Cliente { get; set;}
        [Required]
        public string Destino { get; set;}
        [Required]
        public DateTime Data { get; set;}

        public int Teletone { get; set;}


    }
}
