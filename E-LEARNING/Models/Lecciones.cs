using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace E_LEARNING.Models
{
    public class Lecciones
    {
        [Required]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdLeccion { get; set; }
        public string Titulo { get; set; }
        public String Contenido { get; set; }
        public CursoProfe CursoProfe { get; set; }

    }
}