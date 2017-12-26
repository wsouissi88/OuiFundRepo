namespace OuiFund.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AnalyseFirstSurvey : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Questionnaire", "AnalysePointForts", c => c.String());
            AddColumn("dbo.Questionnaire", "AnalysePointFaibles", c => c.String());
            AddColumn("dbo.Questionnaire", "AnalysePointaAmrliorer", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Questionnaire", "AnalysePointaAmrliorer");
            DropColumn("dbo.Questionnaire", "AnalysePointFaibles");
            DropColumn("dbo.Questionnaire", "AnalysePointForts");
        }
    }
}
