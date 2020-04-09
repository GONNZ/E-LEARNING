namespace E_LEARNING.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixCursoProfe2 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.TB_CursoProfe");
            AlterColumn("dbo.TB_CursoProfe", "idProfe", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.TB_CursoProfe", new[] { "idCurso", "idProfe" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.TB_CursoProfe");
            AlterColumn("dbo.TB_CursoProfe", "idProfe", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.TB_CursoProfe", new[] { "idCurso", "idProfe" });
        }
    }
}
