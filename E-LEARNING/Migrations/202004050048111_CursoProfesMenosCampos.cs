namespace E_LEARNING.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CursoProfesMenosCampos : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TB_CursoProfe", "Profe_Id", "dbo.AspNetUsers");
            DropIndex("dbo.TB_CursoProfe", new[] { "Profe_Id" });
            RenameColumn(table: "dbo.TB_CursoProfe", name: "IdCurso", newName: "Curso_IdCurso");
            RenameIndex(table: "dbo.TB_CursoProfe", name: "IX_IdCurso", newName: "IX_Curso_IdCurso");
            AlterColumn("dbo.TB_CursoProfe", "Profe_Id", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.TB_CursoProfe", "Profe_Id");
            AddForeignKey("dbo.TB_CursoProfe", "Profe_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            DropColumn("dbo.TB_CursoProfe", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TB_CursoProfe", "Id", c => c.Int(nullable: false));
            DropForeignKey("dbo.TB_CursoProfe", "Profe_Id", "dbo.AspNetUsers");
            DropIndex("dbo.TB_CursoProfe", new[] { "Profe_Id" });
            AlterColumn("dbo.TB_CursoProfe", "Profe_Id", c => c.String(maxLength: 128));
            RenameIndex(table: "dbo.TB_CursoProfe", name: "IX_Curso_IdCurso", newName: "IX_IdCurso");
            RenameColumn(table: "dbo.TB_CursoProfe", name: "Curso_IdCurso", newName: "IdCurso");
            CreateIndex("dbo.TB_CursoProfe", "Profe_Id");
            AddForeignKey("dbo.TB_CursoProfe", "Profe_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
