namespace E_LEARNING.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialUsersIdentity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "nombre", c => c.String());
            AddColumn("dbo.AspNetUsers", "cedula", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "apellidos", c => c.String());
            AddColumn("dbo.AspNetUsers", "fechaNacimiento", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "fechaNacimiento");
            DropColumn("dbo.AspNetUsers", "apellidos");
            DropColumn("dbo.AspNetUsers", "cedula");
            DropColumn("dbo.AspNetUsers", "nombre");
        }
    }
}
