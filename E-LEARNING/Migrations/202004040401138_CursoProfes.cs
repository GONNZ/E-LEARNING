namespace E_LEARNING.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CursoProfes : DbMigration
    {
        public override void Up()
        {
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TB_CursoProfe", "Profe_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.TB_CursoProfe", "Curso_IdCurso", "dbo.TB_Cursos");
            DropIndex("dbo.TB_CursoProfe", new[] { "Profe_Id" });
            DropIndex("dbo.TB_CursoProfe", new[] { "Curso_IdCurso" });
            DropTable("dbo.TB_CursoProfe");
        }
    }
}
