namespace E_LEARNING.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixCursoProfe : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.TB_CursoProfe");
            AddPrimaryKey("dbo.TB_CursoProfe", new[] { "idCurso", "idProfe" });
            DropColumn("dbo.TB_CursoProfe", "IdCursoProfe");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TB_CursoProfe", "IdCursoProfe", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.TB_CursoProfe");
            AddPrimaryKey("dbo.TB_CursoProfe", "IdCursoProfe");
        }
    }
}
