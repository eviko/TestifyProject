namespace Testify.Ef.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PossibleAnswers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        QuestionTemplateId = c.Int(nullable: false),
                        Answer = c.String(),
                        Explanation = c.String(),
                        IsTheCorrect = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.QuestionTemplates", t => t.QuestionTemplateId, cascadeDelete: true)
                .Index(t => t.QuestionTemplateId);
            
            CreateTable(
                "dbo.QuestionTemplates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TestTemplateId = c.Int(nullable: false),
                        QuestionOrder = c.Int(nullable: false),
                        Question = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TestTemplates", t => t.TestTemplateId, cascadeDelete: true)
                .Index(t => t.TestTemplateId);
            
            CreateTable(
                "dbo.TestTemplates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        QuestionsPerPage = c.Int(nullable: false),
                        MinutesToComplete = c.Int(nullable: false),
                        ScoreToPass = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.QuestionTemplates", "TestTemplateId", "dbo.TestTemplates");
            DropForeignKey("dbo.PossibleAnswers", "QuestionTemplateId", "dbo.QuestionTemplates");
            DropIndex("dbo.QuestionTemplates", new[] { "TestTemplateId" });
            DropIndex("dbo.PossibleAnswers", new[] { "QuestionTemplateId" });
            DropTable("dbo.TestTemplates");
            DropTable("dbo.QuestionTemplates");
            DropTable("dbo.PossibleAnswers");
        }
    }
}
