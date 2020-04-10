using IdentitySample.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace E_LEARNING.Models
{
    public class Matricula
    {
        [Required]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdMatricula { get; set; }

        public ApplicationUser Alumno { get; set; }

        public CursoProfe CursoProfe { get; set; }
    }
}