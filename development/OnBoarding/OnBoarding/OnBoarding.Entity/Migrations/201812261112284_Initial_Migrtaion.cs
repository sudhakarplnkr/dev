namespace OnBoarding.EntityContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial_Migrtaion : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProjectTeam",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ProjectId = c.Guid(nullable: false),
                        TeamId = c.Guid(nullable: false),
                        ScrumMaster = c.String(),
                        ProductOwner = c.String(),
                        ClientDeveloper = c.String(),
                        ClientTester = c.String(),
                        ClientBusinessAnalyst = c.String(),
                        ClientUserInterface = c.String(),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Project", t => t.ProjectId)
                .ForeignKey("dbo.Team", t => t.TeamId)
                .Index(t => t.ProjectId)
                .Index(t => t.TeamId);
            
            CreateTable(
                "dbo.Project",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Code = c.String(),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Team",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Code = c.String(),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProjectPlan",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ProjectId = c.Guid(nullable: false),
                        RoleId = c.Guid(nullable: false),
                        Week = c.Int(nullable: false),
                        Day = c.Int(nullable: false),
                        KnowledgeTransferId = c.Guid(nullable: false),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.KnowledgeTransfer", t => t.KnowledgeTransferId)
                .ForeignKey("dbo.Project", t => t.ProjectId)
                .ForeignKey("dbo.Role", t => t.RoleId)
                .Index(t => t.ProjectId)
                .Index(t => t.RoleId)
                .Index(t => t.KnowledgeTransferId);
            
            CreateTable(
                "dbo.KnowledgeTransfer",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        ModeId = c.Guid(nullable: false),
                        OwnerId = c.Guid(),
                        Reference = c.String(),
                        Duration = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Mode", t => t.ModeId)
                .ForeignKey("dbo.Associate", t => t.OwnerId)
                .Index(t => t.ModeId)
                .Index(t => t.OwnerId);
            
            CreateTable(
                "dbo.Mode",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Code = c.String(),
                        Name = c.String(),
                        ProofType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Associate",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Code = c.String(),
                        ProjectId = c.Guid(nullable: false),
                        RoleId = c.Guid(nullable: false),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Project", t => t.ProjectId)
                .ForeignKey("dbo.Role", t => t.RoleId)
                .Index(t => t.ProjectId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AssociateDetails",
                c => new
                    {
                        AssociateId = c.Guid(nullable: false),
                        DesignationId = c.Guid(),
                        FNZUserName = c.String(),
                        FNZStaffId = c.String(),
                        FNZRoleId = c.Guid(),
                        FNZEmail = c.String(),
                        AssetNo = c.String(),
                        VirtualMachineNo = c.String(),
                        Portfolio = c.String(),
                        FNZDateofJoining = c.DateTime(),
                        FNZDateofLeaving = c.DateTime(),
                        FNZExperience = c.Int(),
                        Billable = c.String(),
                        Location = c.String(),
                        ContactNo = c.String(),
                        TeamId = c.Guid(),
                        EmailId = c.String(),
                        City = c.String(),
                        SkillSet = c.String(),
                        ExperienceOfAssociate = c.Int(),
                        Fse = c.Boolean(),
                    })
                .PrimaryKey(t => t.AssociateId)
                .ForeignKey("dbo.Associate", t => t.AssociateId)
                .ForeignKey("dbo.Designation", t => t.DesignationId)
                .ForeignKey("dbo.Team", t => t.TeamId)
                .Index(t => t.AssociateId)
                .Index(t => t.DesignationId)
                .Index(t => t.TeamId);
            
            CreateTable(
                "dbo.Designation",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Code = c.String(),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Code = c.String(),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProjectGroupPlan",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ProjectGroupId = c.Guid(nullable: false),
                        RoleId = c.Guid(nullable: false),
                        Week = c.Int(nullable: false),
                        Day = c.Int(nullable: false),
                        KnowledgeTransferId = c.Guid(nullable: false),
                        ModeId = c.Guid(nullable: false),
                        OwnerId = c.Guid(),
                        Reference = c.String(),
                        ScheduledDate = c.DateTime(nullable: false),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProjectGroup", t => t.ProjectGroupId)
                .ForeignKey("dbo.KnowledgeTransfer", t => t.KnowledgeTransferId)
                .ForeignKey("dbo.Mode", t => t.ModeId)
                .ForeignKey("dbo.Associate", t => t.OwnerId)
                .ForeignKey("dbo.Role", t => t.RoleId)
                .Index(t => t.ProjectGroupId)
                .Index(t => t.RoleId)
                .Index(t => t.KnowledgeTransferId)
                .Index(t => t.ModeId)
                .Index(t => t.OwnerId);
            
            CreateTable(
                "dbo.AssociatePlan",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        AssociateGroupId = c.Guid(nullable: false),
                        ProjectGroupPlanId = c.Guid(nullable: false),
                        Status = c.Boolean(nullable: false),
                        CompletionDate = c.DateTime(),
                        Proof = c.Binary(),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AssociateGroup", t => t.AssociateGroupId)
                .ForeignKey("dbo.ProjectGroupPlan", t => t.ProjectGroupPlanId)
                .Index(t => t.AssociateGroupId)
                .Index(t => t.ProjectGroupPlanId);
            
            CreateTable(
                "dbo.AssociateGroup",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ProjectGroupId = c.Guid(nullable: false),
                        AssociateId = c.Guid(nullable: false),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Associate", t => t.AssociateId)
                .ForeignKey("dbo.ProjectGroup", t => t.ProjectGroupId)
                .Index(t => t.ProjectGroupId)
                .Index(t => t.AssociateId);
            
            CreateTable(
                "dbo.ProjectGroup",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ProjectId = c.Guid(nullable: false),
                        Name = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        Description = c.String(),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Project", t => t.ProjectId)
                .Index(t => t.ProjectId);
            
            CreateTable(
                "dbo.AssociateProject",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ProjectId = c.Guid(nullable: false),
                        AssociateId = c.Guid(nullable: false),
                        Status = c.Boolean(nullable: false),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Associate", t => t.AssociateId)
                .ForeignKey("dbo.Project", t => t.ProjectId)
                .Index(t => t.ProjectId)
                .Index(t => t.AssociateId);
            
            CreateTable(
                "dbo.AssociateUserRole",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        AssociateId = c.Guid(nullable: false),
                        UserRoleId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Associate", t => t.AssociateId)
                .ForeignKey("dbo.UserRole", t => t.UserRoleId)
                .Index(t => t.AssociateId)
                .Index(t => t.UserRoleId);
            
            CreateTable(
                "dbo.UserRole",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AccountRole",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Code = c.String(),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AssociateUserRole", "UserRoleId", "dbo.UserRole");
            DropForeignKey("dbo.AssociateUserRole", "AssociateId", "dbo.Associate");
            DropForeignKey("dbo.AssociateProject", "ProjectId", "dbo.Project");
            DropForeignKey("dbo.AssociateProject", "AssociateId", "dbo.Associate");
            DropForeignKey("dbo.ProjectGroupPlan", "RoleId", "dbo.Role");
            DropForeignKey("dbo.ProjectGroupPlan", "OwnerId", "dbo.Associate");
            DropForeignKey("dbo.ProjectGroupPlan", "ModeId", "dbo.Mode");
            DropForeignKey("dbo.ProjectGroupPlan", "KnowledgeTransferId", "dbo.KnowledgeTransfer");
            DropForeignKey("dbo.AssociatePlan", "ProjectGroupPlanId", "dbo.ProjectGroupPlan");
            DropForeignKey("dbo.ProjectGroupPlan", "ProjectGroupId", "dbo.ProjectGroup");
            DropForeignKey("dbo.ProjectGroup", "ProjectId", "dbo.Project");
            DropForeignKey("dbo.AssociateGroup", "ProjectGroupId", "dbo.ProjectGroup");
            DropForeignKey("dbo.AssociatePlan", "AssociateGroupId", "dbo.AssociateGroup");
            DropForeignKey("dbo.AssociateGroup", "AssociateId", "dbo.Associate");
            DropForeignKey("dbo.ProjectPlan", "RoleId", "dbo.Role");
            DropForeignKey("dbo.ProjectPlan", "ProjectId", "dbo.Project");
            DropForeignKey("dbo.ProjectPlan", "KnowledgeTransferId", "dbo.KnowledgeTransfer");
            DropForeignKey("dbo.KnowledgeTransfer", "OwnerId", "dbo.Associate");
            DropForeignKey("dbo.Associate", "RoleId", "dbo.Role");
            DropForeignKey("dbo.Associate", "ProjectId", "dbo.Project");
            DropForeignKey("dbo.AssociateDetails", "TeamId", "dbo.Team");
            DropForeignKey("dbo.AssociateDetails", "DesignationId", "dbo.Designation");
            DropForeignKey("dbo.AssociateDetails", "AssociateId", "dbo.Associate");
            DropForeignKey("dbo.KnowledgeTransfer", "ModeId", "dbo.Mode");
            DropForeignKey("dbo.ProjectTeam", "TeamId", "dbo.Team");
            DropForeignKey("dbo.ProjectTeam", "ProjectId", "dbo.Project");
            DropIndex("dbo.AssociateUserRole", new[] { "UserRoleId" });
            DropIndex("dbo.AssociateUserRole", new[] { "AssociateId" });
            DropIndex("dbo.AssociateProject", new[] { "AssociateId" });
            DropIndex("dbo.AssociateProject", new[] { "ProjectId" });
            DropIndex("dbo.ProjectGroup", new[] { "ProjectId" });
            DropIndex("dbo.AssociateGroup", new[] { "AssociateId" });
            DropIndex("dbo.AssociateGroup", new[] { "ProjectGroupId" });
            DropIndex("dbo.AssociatePlan", new[] { "ProjectGroupPlanId" });
            DropIndex("dbo.AssociatePlan", new[] { "AssociateGroupId" });
            DropIndex("dbo.ProjectGroupPlan", new[] { "OwnerId" });
            DropIndex("dbo.ProjectGroupPlan", new[] { "ModeId" });
            DropIndex("dbo.ProjectGroupPlan", new[] { "KnowledgeTransferId" });
            DropIndex("dbo.ProjectGroupPlan", new[] { "RoleId" });
            DropIndex("dbo.ProjectGroupPlan", new[] { "ProjectGroupId" });
            DropIndex("dbo.AssociateDetails", new[] { "TeamId" });
            DropIndex("dbo.AssociateDetails", new[] { "DesignationId" });
            DropIndex("dbo.AssociateDetails", new[] { "AssociateId" });
            DropIndex("dbo.Associate", new[] { "RoleId" });
            DropIndex("dbo.Associate", new[] { "ProjectId" });
            DropIndex("dbo.KnowledgeTransfer", new[] { "OwnerId" });
            DropIndex("dbo.KnowledgeTransfer", new[] { "ModeId" });
            DropIndex("dbo.ProjectPlan", new[] { "KnowledgeTransferId" });
            DropIndex("dbo.ProjectPlan", new[] { "RoleId" });
            DropIndex("dbo.ProjectPlan", new[] { "ProjectId" });
            DropIndex("dbo.ProjectTeam", new[] { "TeamId" });
            DropIndex("dbo.ProjectTeam", new[] { "ProjectId" });
            DropTable("dbo.AccountRole");
            DropTable("dbo.UserRole");
            DropTable("dbo.AssociateUserRole");
            DropTable("dbo.AssociateProject");
            DropTable("dbo.ProjectGroup");
            DropTable("dbo.AssociateGroup");
            DropTable("dbo.AssociatePlan");
            DropTable("dbo.ProjectGroupPlan");
            DropTable("dbo.Role");
            DropTable("dbo.Designation");
            DropTable("dbo.AssociateDetails");
            DropTable("dbo.Associate");
            DropTable("dbo.Mode");
            DropTable("dbo.KnowledgeTransfer");
            DropTable("dbo.ProjectPlan");
            DropTable("dbo.Team");
            DropTable("dbo.Project");
            DropTable("dbo.ProjectTeam");
        }
    }
}
