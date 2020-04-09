using IdentitySample.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace E_LEARNING.Models
{
    [Table("TB_CursoProfe")]
    public class CursoProfe
    {
        [Required]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCursoProfe { get; set; }
        [Required]
        public ApplicationUser Profe { get; set; }
        [Required]
        public Curso Curso { get; set; }
 
    }
}