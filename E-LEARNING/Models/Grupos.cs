using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace E_LEARNING.Models
{
    public class Grupos
    {
        [Required]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdGrupo { get; set; }
        public string horario { get; set; }
        public CursoProfe CursoProfe { get; set; }
        public List<Matricula> Matricula { get; set; }
    }
}