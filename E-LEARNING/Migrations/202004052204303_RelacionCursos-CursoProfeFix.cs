namespace E_LEARNING.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RelacionCursosCursoProfeFix : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TB_CursoProfe", "idProfe", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TB_CursoProfe", "idProfe", c => c.Int(nullable: false));
        }
    }
}
