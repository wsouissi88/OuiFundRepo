namespace OuiFund.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reponse : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reponse", "AnalyseReponsePointsForts", c => c.String());
            AddColumn("dbo.Reponse", "AnalyseReponsePointsFaibles", c => c.String());
            AddColumn("dbo.Reponse", "AnalyseReponsePointsaAmeliorer", c => c.String());
            DropColumn("dbo.Reponse", "AnalyseReponse");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reponse", "AnalyseReponse", c => c.String());
            DropColumn("dbo.Reponse", "AnalyseReponsePointsaAmeliorer");
            DropColumn("dbo.Reponse", "AnalyseReponsePointsFaibles");
            DropColumn("dbo.Reponse", "AnalyseReponsePointsForts");
        }
    }
}
