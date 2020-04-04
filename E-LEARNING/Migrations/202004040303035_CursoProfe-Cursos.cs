namespace E_LEARNING.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CursoProfeCursos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TB_Cursos",
                c => new
                    {
                        IdCurso = c.Int(nullable: false, identity: true),
                        CodigoCurso = c.String(nullable: false),
                        NombreCurso = c.String(nullable: false),
                        DescripcionCurso = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.IdCurso);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TB_Cursos");
        }
    }
}
