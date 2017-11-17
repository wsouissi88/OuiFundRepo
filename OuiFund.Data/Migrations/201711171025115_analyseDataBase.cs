namespace OuiFund.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class analyseDataBase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Analyse",
                c => new
                    {
                        AnalyseID = c.Int(nullable: false, identity: true),
                        AnalyseModel = c.String(),
                        TypeAnalyse = c.Int(nullable: false),
                        QuestionId = c.Int(),
                        ReponseId = c.Int(),
                        NoteQuestion = c.Int(),
                        TextQuestion = c.String(),
                        UtilisateurId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AnalyseID)
                .ForeignKey("dbo.Question", t => t.QuestionId, cascadeDelete: true)
                .ForeignKey("dbo.Reponse", t => t.ReponseId)
                .ForeignKey("dbo.Utilisateur", t => t.UtilisateurId, cascadeDelete: true)
                .Index(t => t.QuestionId)
                .Index(t => t.ReponseId)
                .Index(t => t.UtilisateurId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Analyse", "UtilisateurId", "dbo.Utilisateur");
            DropForeignKey("dbo.Analyse", "ReponseId", "dbo.Reponse");
            DropForeignKey("dbo.Analyse", "QuestionId", "dbo.Question");
            DropIndex("dbo.Analyse", new[] { "UtilisateurId" });
            DropIndex("dbo.Analyse", new[] { "ReponseId" });
            DropIndex("dbo.Analyse", new[] { "QuestionId" });
            DropTable("dbo.Analyse");
        }
    }
}
