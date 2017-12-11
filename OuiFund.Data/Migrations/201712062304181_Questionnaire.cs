namespace OuiFund.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Questionnaire : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Questionnaire",
                c => new
                    {
                        QuestionnaireID = c.Int(nullable: false, identity: true),
                        DateCreation = c.DateTime(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.QuestionnaireID)
                .ForeignKey("dbo.Utilisateur", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.QuestionReponse",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        QuestionID = c.Int(nullable: false),
                        ReponseSelected = c.Int(nullable: false),
                        ReponseString = c.String(),
                        QuestionnaireID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Question", t => t.QuestionID, cascadeDelete: true)
                .ForeignKey("dbo.Questionnaire", t => t.QuestionnaireID, cascadeDelete: true)
                .Index(t => t.QuestionID)
                .Index(t => t.QuestionnaireID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Questionnaire", "UserId", "dbo.Utilisateur");
            DropForeignKey("dbo.QuestionReponse", "QuestionnaireID", "dbo.Questionnaire");
            DropForeignKey("dbo.QuestionReponse", "QuestionID", "dbo.Question");
            DropIndex("dbo.QuestionReponse", new[] { "QuestionnaireID" });
            DropIndex("dbo.QuestionReponse", new[] { "QuestionID" });
            DropIndex("dbo.Questionnaire", new[] { "UserId" });
            DropTable("dbo.QuestionReponse");
            DropTable("dbo.Questionnaire");
        }
    }
}
