namespace E_LEARNING.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MatriculaFix : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Matriculas", "IdGrupo", "dbo.Grupos");
            DropIndex("dbo.Matriculas", new[] { "IdGrupo" });
            RenameColumn(table: "dbo.Matriculas", name: "ApplicationUser_Id", newName: "Alumno_Id");
            RenameColumn(table: "dbo.Matriculas", name: "IdGrupo", newName: "Grupo_IdGrupo");
            RenameIndex(table: "dbo.Matriculas", name: "IX_ApplicationUser_Id", newName: "IX_Alumno_Id");
            AlterColumn("dbo.Matriculas", "Grupo_IdGrupo", c => c.Int());
            CreateIndex("dbo.Matriculas", "Grupo_IdGrupo");
            AddForeignKey("dbo.Matriculas", "Grupo_IdGrupo", "dbo.Grupos", "IdGrupo");
            DropColumn("dbo.Matriculas", "IdAlumno");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Matriculas", "IdAlumno", c => c.String());
            DropForeignKey("dbo.Matriculas", "Grupo_IdGrupo", "dbo.Grupos");
            DropIndex("dbo.Matriculas", new[] { "Grupo_IdGrupo" });
            AlterColumn("dbo.Matriculas", "Grupo_IdGrupo", c => c.Int(nullable: false));
            RenameIndex(table: "dbo.Matriculas", name: "IX_Alumno_Id", newName: "IX_ApplicationUser_Id");
            RenameColumn(table: "dbo.Matriculas", name: "Grupo_IdGrupo", newName: "IdGrupo");
            RenameColumn(table: "dbo.Matriculas", name: "Alumno_Id", newName: "ApplicationUser_Id");
            CreateIndex("dbo.Matriculas", "IdGrupo");
            AddForeignKey("dbo.Matriculas", "IdGrupo", "dbo.Grupos", "IdGrupo", cascadeDelete: true);
        }
    }
}
