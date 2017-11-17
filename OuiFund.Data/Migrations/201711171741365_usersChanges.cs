namespace OuiFund.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class usersChanges : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Adherent", "UtilisateurID", "dbo.Utilisateur");
            DropForeignKey("dbo.Client", "UtilisateurID", "dbo.Adherent");
            DropIndex("dbo.Adherent", new[] { "UtilisateurID" });
            DropIndex("dbo.Client", new[] { "UtilisateurID" });
            AddColumn("dbo.Utilisateur", "NomUser", c => c.String());
            AddColumn("dbo.Utilisateur", "PrenomUser", c => c.String());
            AddColumn("dbo.Utilisateur", "TelUser", c => c.String());
            AddColumn("dbo.Utilisateur", "DateNaissance", c => c.DateTime());
            AddColumn("dbo.Utilisateur", "dossierId", c => c.Int());
            AddColumn("dbo.Utilisateur", "NiveauEtude", c => c.String());
            AddColumn("dbo.Utilisateur", "AnneeExperience", c => c.Int());
            AddColumn("dbo.Utilisateur", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Utilisateur", "UtilisateurID");
            DropTable("dbo.Adherent");
            DropTable("dbo.Client");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Client",
                c => new
                    {
                        UtilisateurID = c.Int(nullable: false),
                        NiveauEtude = c.String(),
                        AnneeExperience = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UtilisateurID);
            
            CreateTable(
                "dbo.Adherent",
                c => new
                    {
                        UtilisateurID = c.Int(nullable: false),
                        NomUser = c.String(nullable: false),
                        PrenomUser = c.String(),
                        TelUser = c.String(nullable: false),
                        DateNaissance = c.DateTime(nullable: false),
                        dossierId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UtilisateurID);
            
            DropIndex("dbo.Utilisateur", new[] { "UtilisateurID" });
            DropColumn("dbo.Utilisateur", "Discriminator");
            DropColumn("dbo.Utilisateur", "AnneeExperience");
            DropColumn("dbo.Utilisateur", "NiveauEtude");
            DropColumn("dbo.Utilisateur", "dossierId");
            DropColumn("dbo.Utilisateur", "DateNaissance");
            DropColumn("dbo.Utilisateur", "TelUser");
            DropColumn("dbo.Utilisateur", "PrenomUser");
            DropColumn("dbo.Utilisateur", "NomUser");
            CreateIndex("dbo.Client", "UtilisateurID");
            CreateIndex("dbo.Adherent", "UtilisateurID");
            AddForeignKey("dbo.Client", "UtilisateurID", "dbo.Adherent", "UtilisateurID");
            AddForeignKey("dbo.Adherent", "UtilisateurID", "dbo.Utilisateur", "UtilisateurID");
        }
    }
}
