namespace E_LEARNING.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CursoProfeGruposMatricula : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.TB_CursoProfe");
            CreateTable(
                "dbo.Grupos",
                c => new
                    {
                        IdGrupo = c.Int(nullable: false, identity: true),
                        CursoProfeId = c.Int(nullable: false),
                        horario = c.String(),
                    })
                .PrimaryKey(t => t.IdGrupo);
            
            CreateTable(
                "dbo.Matriculas",
                c => new
                    {
                        IdMatricula = c.Int(nullable: false, identity: true),
                        IdAlumno = c.String(),
                        IdGrupo = c.Int(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.IdMatricula)
                .ForeignKey("dbo.Grupos", t => t.IdGrupo, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.IdGrupo)
                .Index(t => t.ApplicationUser_Id);
            
            AddColumn("dbo.TB_CursoProfe", "IdCursoProfe", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.TB_CursoProfe", "Grupo_IdGrupo", c => c.Int());
            AlterColumn("dbo.TB_CursoProfe", "idProfe", c => c.String());
            AddPrimaryKey("dbo.TB_CursoProfe", "IdCursoProfe");
            CreateIndex("dbo.TB_CursoProfe", "Grupo_IdGrupo");
            AddForeignKey("dbo.TB_CursoProfe", "Grupo_IdGrupo", "dbo.Grupos", "IdGrupo");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Matriculas", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.TB_CursoProfe", "Grupo_IdGrupo", "dbo.Grupos");
            DropForeignKey("dbo.Matriculas", "IdGrupo", "dbo.Grupos");
            DropIndex("dbo.Matriculas", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Matriculas", new[] { "IdGrupo" });
            DropIndex("dbo.TB_CursoProfe", new[] { "Grupo_IdGrupo" });
            DropPrimaryKey("dbo.TB_CursoProfe");
            AlterColumn("dbo.TB_CursoProfe", "idProfe", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.TB_CursoProfe", "Grupo_IdGrupo");
            DropColumn("dbo.TB_CursoProfe", "IdCursoProfe");
            DropTable("dbo.Matriculas");
            DropTable("dbo.Grupos");
            AddPrimaryKey("dbo.TB_CursoProfe", new[] { "idCurso", "idProfe" });
        }
    }
}
