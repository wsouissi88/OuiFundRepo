namespace OuiFund.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class QuestionnaireType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Questionnaire", "Questionnairetype", c => c.Int(nullable: false, defaultValue:1));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Questionnaire", "Questionnairetype");
        }
    }
}
