using IdentitySample.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace E_LEARNING.Models
{
    public class Comentarios
    {
        [Required]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdComentario { get; set; }
        public string Comentario { get; set; }
        public Lecciones Leccion { get; set; }
        public ApplicationUser Usuario { get; set; }

    }
}