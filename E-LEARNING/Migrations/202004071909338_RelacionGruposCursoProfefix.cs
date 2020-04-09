namespace E_LEARNING.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RelacionGruposCursoProfefix : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TB_CursoProfe", "Grupo_IdGrupo", "dbo.Grupos");
            DropIndex("dbo.TB_CursoProfe", new[] { "Grupo_IdGrupo" });
            AddColumn("dbo.Grupos", "CursoProfe_IdCursoProfe", c => c.Int());
            CreateIndex("dbo.Grupos", "CursoProfe_IdCursoProfe");
            AddForeignKey("dbo.Grupos", "CursoProfe_IdCursoProfe", "dbo.TB_CursoProfe", "IdCursoProfe");
            DropColumn("dbo.TB_CursoProfe", "Grupo_IdGrupo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TB_CursoProfe", "Grupo_IdGrupo", c => c.Int());
            DropForeignKey("dbo.Grupos", "CursoProfe_IdCursoProfe", "dbo.TB_CursoProfe");
            DropIndex("dbo.Grupos", new[] { "CursoProfe_IdCursoProfe" });
            DropColumn("dbo.Grupos", "CursoProfe_IdCursoProfe");
            CreateIndex("dbo.TB_CursoProfe", "Grupo_IdGrupo");
            AddForeignKey("dbo.TB_CursoProfe", "Grupo_IdGrupo", "dbo.Grupos", "IdGrupo");
        }
    }
}
