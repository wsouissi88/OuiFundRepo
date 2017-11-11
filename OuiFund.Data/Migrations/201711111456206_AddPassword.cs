namespace OuiFund.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPassword : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Utilisateur", "Password", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Utilisateur", "Password");
        }
    }
}
