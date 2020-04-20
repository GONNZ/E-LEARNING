namespace E_LEARNING.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Archivoes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Creado = c.DateTime(nullable: false),
                        Nombre = c.String(nullable: false, maxLength: 100),
                        Extension = c.String(nullable: false, maxLength: 4),
                        Tipo = c.String(nullable: false),
                        lecciones_IdLeccion = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Lecciones", t => t.lecciones_IdLeccion)
                .Index(t => t.lecciones_IdLeccion);
            
            CreateTable(
                "dbo.Lecciones",
                c => new
                    {
                        IdLeccion = c.Int(nullable: false, identity: true),
                        Titulo = c.String(),
                        Contenido = c.String(),
                        CursoProfe_IdCursoProfe = c.Int(),
                    })
                .PrimaryKey(t => t.IdLeccion)
                .ForeignKey("dbo.TB_CursoProfe", t => t.CursoProfe_IdCursoProfe)
                .Index(t => t.CursoProfe_IdCursoProfe);
            
            CreateTable(
                "dbo.TB_CursoProfe",
                c => new
                    {
                        IdCursoProfe = c.Int(nullable: false, identity: true),
                        Curso_IdCurso = c.Int(nullable: false),
                        Profe_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.IdCursoProfe)
                .ForeignKey("dbo.TB_Cursos", t => t.Curso_IdCurso, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.Profe_Id, cascadeDelete: true)
                .Index(t => t.Curso_IdCurso)
                .Index(t => t.Profe_Id);
            
            CreateTable(
                "dbo.TB_Cursos",
                c => new
                    {
                        IdCurso = c.Int(nullable: false, identity: true),
                        CodigoCurso = c.String(nullable: false),
                        NombreCurso = c.String(nullable: false),
                        DescripcionCurso = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.IdCurso);
            
            CreateTable(
                "dbo.Matriculas",
                c => new
                    {
                        IdMatricula = c.Int(nullable: false, identity: true),
                        Alumno_Id = c.String(maxLength: 128),
                        CursoProfe_IdCursoProfe = c.Int(),
                    })
                .PrimaryKey(t => t.IdMatricula)
                .ForeignKey("dbo.AspNetUsers", t => t.Alumno_Id)
                .ForeignKey("dbo.TB_CursoProfe", t => t.CursoProfe_IdCursoProfe)
                .Index(t => t.Alumno_Id)
                .Index(t => t.CursoProfe_IdCursoProfe);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        nombre = c.String(),
                        cedula = c.Int(nullable: false),
                        apellidos = c.String(),
                        fechaNacimiento = c.DateTime(nullable: false),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                        descripcion = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.TB_CursoProfe", "Profe_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Matriculas", "CursoProfe_IdCursoProfe", "dbo.TB_CursoProfe");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Matriculas", "Alumno_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Lecciones", "CursoProfe_IdCursoProfe", "dbo.TB_CursoProfe");
            DropForeignKey("dbo.TB_CursoProfe", "Curso_IdCurso", "dbo.TB_Cursos");
            DropForeignKey("dbo.Archivoes", "lecciones_IdLeccion", "dbo.Lecciones");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Matriculas", new[] { "CursoProfe_IdCursoProfe" });
            DropIndex("dbo.Matriculas", new[] { "Alumno_Id" });
            DropIndex("dbo.TB_CursoProfe", new[] { "Profe_Id" });
            DropIndex("dbo.TB_CursoProfe", new[] { "Curso_IdCurso" });
            DropIndex("dbo.Lecciones", new[] { "CursoProfe_IdCursoProfe" });
            DropIndex("dbo.Archivoes", new[] { "lecciones_IdLeccion" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Matriculas");
            DropTable("dbo.TB_Cursos");
            DropTable("dbo.TB_CursoProfe");
            DropTable("dbo.Lecciones");
            DropTable("dbo.Archivoes");
        }
    }
}
