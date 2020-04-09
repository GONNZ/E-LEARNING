namespace E_LEARNING.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class prueba : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.TB_CursoProfe", name: "idCurso", newName: "Curso_IdCurso");
            RenameIndex(table: "dbo.TB_CursoProfe", name: "IX_idCurso", newName: "IX_Curso_IdCurso");
            DropColumn("dbo.TB_CursoProfe", "idProfe");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TB_CursoProfe", "idProfe", c => c.String());
            RenameIndex(table: "dbo.TB_CursoProfe", name: "IX_Curso_IdCurso", newName: "IX_idCurso");
            RenameColumn(table: "dbo.TB_CursoProfe", name: "Curso_IdCurso", newName: "idCurso");
        }
    }
}
