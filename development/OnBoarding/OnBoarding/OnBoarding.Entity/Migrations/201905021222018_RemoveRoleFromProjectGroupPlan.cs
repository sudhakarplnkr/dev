namespace OnBoarding.EntityContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveRoleFromProjectGroupPlan : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProjectGroupPlan", "RoleId", "dbo.Role");
            DropIndex("dbo.ProjectGroupPlan", new[] { "RoleId" });
            DropColumn("dbo.ProjectGroupPlan", "RoleId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProjectGroupPlan", "RoleId", c => c.Guid(nullable: false));
            CreateIndex("dbo.ProjectGroupPlan", "RoleId");
            AddForeignKey("dbo.ProjectGroupPlan", "RoleId", "dbo.Role", "Id");
        }
    }
}
