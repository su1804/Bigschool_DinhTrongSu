namespace Bigschool_DinhTrongSu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTableCourse : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LecturerId = c.String(nullable: false, maxLength: 128),
                        Palce = c.String(nullable: false, maxLength: 255),
                        DateTime = c.DateTime(nullable: false),
                        category_Id = c.Byte(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.category_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.LecturerId, cascadeDelete: true)
                .Index(t => t.LecturerId)
                .Index(t => t.category_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.courses", "LecturerId", "dbo.AspNetUsers");
            DropForeignKey("dbo.courses", "category_Id", "dbo.Categories");
            DropIndex("dbo.courses", new[] { "category_Id" });
            DropIndex("dbo.courses", new[] { "LecturerId" });
            DropTable("dbo.courses");
            DropTable("dbo.Categories");
        }
    }
}
