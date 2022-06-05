namespace Bigschool_DinhTrongSu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class abc : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.courses", "category_Id", "dbo.Categories");
            DropIndex("dbo.courses", new[] { "category_Id" });
            RenameColumn(table: "dbo.courses", name: "category_Id", newName: "CategoryId");
            AlterColumn("dbo.courses", "CategoryId", c => c.Byte(nullable: false));
            CreateIndex("dbo.courses", "CategoryId");
            AddForeignKey("dbo.courses", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.courses", "CategoryId", "dbo.Categories");
            DropIndex("dbo.courses", new[] { "CategoryId" });
            AlterColumn("dbo.courses", "CategoryId", c => c.Byte());
            RenameColumn(table: "dbo.courses", name: "CategoryId", newName: "category_Id");
            CreateIndex("dbo.courses", "category_Id");
            AddForeignKey("dbo.courses", "category_Id", "dbo.Categories", "Id");
        }
    }
}
