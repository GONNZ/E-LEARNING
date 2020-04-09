namespace E_LEARNING.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RelacionGruposCursoProfe : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Grupos", "CursoProfeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Grupos", "CursoProfeId", c => c.Int(nullable: false));
        }
    }
}
