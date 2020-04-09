namespace E_LEARNING.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RelacionCursosCursoProfe : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.TB_CursoProfe", name: "Curso_IdCurso", newName: "idCurso");
            RenameIndex(table: "dbo.TB_CursoProfe", name: "IX_Curso_IdCurso", newName: "IX_idCurso");
            AddColumn("dbo.TB_CursoProfe", "idProfe", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TB_CursoProfe", "idProfe");
            RenameIndex(table: "dbo.TB_CursoProfe", name: "IX_idCurso", newName: "IX_Curso_IdCurso");
            RenameColumn(table: "dbo.TB_CursoProfe", name: "idCurso", newName: "Curso_IdCurso");
        }
    }
}
