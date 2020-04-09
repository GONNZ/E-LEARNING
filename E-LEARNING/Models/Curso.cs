using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace E_LEARNING.Models
{
    [Table("TB_Cursos")]
    public class Curso
    {
        [Required]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCurso { get; set; }
        [Required]
        [Display(Name ="Código Curso")]
        public string CodigoCurso { get; set; }
        [Required]
        [Display(Name = "Nombre Curso")]
        public string NombreCurso { get; set; }
        [Required]
        [Display(Name = "Descripción Curso")]
        public string DescripcionCurso { get; set; }

        public List<CursoProfe> CursoProfe { get; set; }
    }

}