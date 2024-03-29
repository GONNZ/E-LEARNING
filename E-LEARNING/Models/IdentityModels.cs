﻿using E_LEARNING.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IdentitySample.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {

        public string nombre { get; set; }
        public int cedula { get; set; }
        public string apellidos { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:dd-MM-yyyy}", ApplyFormatInEditMode =true)]
        public DateTime fechaNacimiento { get; set; }
        public List<CursoProfe> CursoProfe { get; set; }
        public List<Matricula> Matriculas { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class AplicationRole : IdentityRole 
    {
        public AplicationRole() : base() { }
        public AplicationRole(string name) : base(name) { }
        public string descripcion { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        static ApplicationDbContext()
        {
            // Set the database intializer which is run once during application start
            // This seeds the database with admin user credentials and admin role
            Database.SetInitializer<ApplicationDbContext>(new ApplicationDbInitializer());
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
       
        public System.Data.Entity.DbSet<E_LEARNING.Models.Curso> Cursoes { get; set; }

        public System.Data.Entity.DbSet<E_LEARNING.Models.CursoProfe> CursoProfes { get; set; }

        public System.Data.Entity.DbSet<E_LEARNING.Models.Matricula> Matriculas { get; set; }

        public System.Data.Entity.DbSet<E_LEARNING.Models.Lecciones> Lecciones { get; set; }
        public System.Data.Entity.DbSet<E_LEARNING.Models.Archivo> Archivos { get; set; }
        public System.Data.Entity.DbSet<E_LEARNING.Models.Comentarios> Comentarios { get; set; }
    }
}