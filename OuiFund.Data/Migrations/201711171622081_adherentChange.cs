namespace OuiFund.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adherentChange : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Adherent", "LoginUser");
            DropColumn("dbo.Adherent", "PasswordUser");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Adherent", "PasswordUser", c => c.String(nullable: false));
            AddColumn("dbo.Adherent", "LoginUser", c => c.String(nullable: false));
        }
    }
}
