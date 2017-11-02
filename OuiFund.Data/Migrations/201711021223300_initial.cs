namespace OuiFund.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Utilisateur",
                c => new
                    {
                        UtilisateurID = c.Int(nullable: false, identity: true),
                        AdresseEmail = c.String(nullable: false),
                        ActiveUser = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UtilisateurID);
            
            CreateTable(
                "dbo.Dossier",
                c => new
                    {
                        DossierID = c.Int(nullable: false, identity: true),
                        StatusDossier = c.String(nullable: false),
                        ReferenceDossier = c.String(nullable: false),
                        adherentId = c.Int(nullable: false),
                        startupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DossierID);
            
            CreateTable(
                "dbo.Document",
                c => new
                    {
                        DocumentID = c.Int(nullable: false, identity: true),
                        TitreDoc = c.String(nullable: false),
                        TypeDoc = c.String(nullable: false),
                        dossierId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DocumentID)
                .ForeignKey("dbo.Dossier", t => t.dossierId, cascadeDelete: true)
                .Index(t => t.dossierId);
            
            CreateTable(
                "dbo.StartUp",
                c => new
                    {
                        StartupID = c.Int(nullable: false),
                        NomStartup = c.String(nullable: false),
                        AdresseStartup = c.String(),
                        VilleStartup = c.String(),
                        CodePostale = c.String(),
                        TelStartup = c.String(),
                        CreationStartup = c.DateTime(nullable: false),
                        dossierId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StartupID)
                .ForeignKey("dbo.Dossier", t => t.StartupID)
                .Index(t => t.StartupID);
            
            CreateTable(
                "dbo.Categorie",
                c => new
                    {
                        CategorieID = c.Int(nullable: false, identity: true),
                        NomCategorie = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CategorieID);
            
            CreateTable(
                "dbo.Question",
                c => new
                    {
                        QuestionID = c.Int(nullable: false, identity: true),
                        DescriptionQuest = c.String(nullable: false),
                        ReferenceQuest = c.String(),
                        TypeQuest = c.Int(nullable: false),
                        StatusQuest = c.Boolean(nullable: false),
                        categorieId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.QuestionID)
                .ForeignKey("dbo.Categorie", t => t.categorieId, cascadeDelete: true)
                .Index(t => t.categorieId);
            
            CreateTable(
                "dbo.Reponse",
                c => new
                    {
                        ReponseID = c.Int(nullable: false, identity: true),
                        TextReponse = c.String(nullable: false),
                        ValeurReponse = c.Int(nullable: false),
                        AnalyseReponse = c.String(),
                        questionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ReponseID)
                .ForeignKey("dbo.Question", t => t.questionId, cascadeDelete: true)
                .Index(t => t.questionId);
            
            CreateTable(
                "dbo.Adherent",
                c => new
                    {
                        UtilisateurID = c.Int(nullable: false),
                        NomUser = c.String(nullable: false),
                        PrenomUser = c.String(),
                        TelUser = c.String(nullable: false),
                        DateNaissance = c.DateTime(nullable: false),
                        LoginUser = c.String(nullable: false),
                        PasswordUser = c.String(nullable: false),
                        dossierId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UtilisateurID)
                .ForeignKey("dbo.Utilisateur", t => t.UtilisateurID)
                .ForeignKey("dbo.Dossier", t => t.UtilisateurID)
                .Index(t => t.UtilisateurID);
            
            CreateTable(
                "dbo.Client",
                c => new
                    {
                        UtilisateurID = c.Int(nullable: false),
                        NiveauEtude = c.String(),
                        AnneeExperience = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UtilisateurID)
                .ForeignKey("dbo.Adherent", t => t.UtilisateurID)
                .Index(t => t.UtilisateurID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Client", "UtilisateurID", "dbo.Adherent");
            DropForeignKey("dbo.Adherent", "UtilisateurID", "dbo.Dossier");
            DropForeignKey("dbo.Adherent", "UtilisateurID", "dbo.Utilisateur");
            DropForeignKey("dbo.Reponse", "questionId", "dbo.Question");
            DropForeignKey("dbo.Question", "categorieId", "dbo.Categorie");
            DropForeignKey("dbo.StartUp", "StartupID", "dbo.Dossier");
            DropForeignKey("dbo.Document", "dossierId", "dbo.Dossier");
            DropIndex("dbo.Client", new[] { "UtilisateurID" });
            DropIndex("dbo.Adherent", new[] { "UtilisateurID" });
            DropIndex("dbo.Reponse", new[] { "questionId" });
            DropIndex("dbo.Question", new[] { "categorieId" });
            DropIndex("dbo.StartUp", new[] { "StartupID" });
            DropIndex("dbo.Document", new[] { "dossierId" });
            DropTable("dbo.Client");
            DropTable("dbo.Adherent");
            DropTable("dbo.Reponse");
            DropTable("dbo.Question");
            DropTable("dbo.Categorie");
            DropTable("dbo.StartUp");
            DropTable("dbo.Document");
            DropTable("dbo.Dossier");
            DropTable("dbo.Utilisateur");
        }
    }
}
