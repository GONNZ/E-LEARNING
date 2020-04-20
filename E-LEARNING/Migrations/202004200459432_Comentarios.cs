namespace E_LEARNING.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Comentarios : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comentarios",
                c => new
                    {
                        IdComentario = c.Int(nullable: false, identity: true),
                        Comentario = c.String(),
                        Leccion_IdLeccion = c.Int(),
                        Usuario_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.IdComentario)
                .ForeignKey("dbo.Lecciones", t => t.Leccion_IdLeccion)
                .ForeignKey("dbo.AspNetUsers", t => t.Usuario_Id)
                .Index(t => t.Leccion_IdLeccion)
                .Index(t => t.Usuario_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comentarios", "Usuario_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Comentarios", "Leccion_IdLeccion", "dbo.Lecciones");
            DropIndex("dbo.Comentarios", new[] { "Usuario_Id" });
            DropIndex("dbo.Comentarios", new[] { "Leccion_IdLeccion" });
            DropTable("dbo.Comentarios");
        }
    }
}
