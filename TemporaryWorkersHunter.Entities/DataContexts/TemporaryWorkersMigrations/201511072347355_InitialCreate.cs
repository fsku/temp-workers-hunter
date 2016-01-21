namespace TemporaryWorkersHunter.Entities.DataContexts.TemporaryWorkersMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Street = c.String(),
                        Number = c.Int(nullable: false),
                        ApartmentNumber = c.Int(nullable: false),
                        ZipCode = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Competences",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ShortName = c.String(),
                        Name = c.String(),
                        Description = c.String(),
                        Worker_Id = c.Int(),
                        OrderRow_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Workers", t => t.Worker_Id)
                .ForeignKey("dbo.OrderRows", t => t.OrderRow_Id)
                .Index(t => t.Worker_Id)
                .Index(t => t.OrderRow_Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderStatus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrderRows",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderedWorker_Id = c.Int(),
                        Order_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Workers", t => t.OrderedWorker_Id)
                .ForeignKey("dbo.Orders", t => t.Order_Id)
                .Index(t => t.OrderedWorker_Id)
                .Index(t => t.Order_Id);
            
            CreateTable(
                "dbo.AvailabilityPeriods",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AvailabeFromDate = c.DateTime(nullable: false),
                        AvailabeToDate = c.DateTime(nullable: false),
                        OrderRow_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.OrderRows", t => t.OrderRow_Id)
                .Index(t => t.OrderRow_Id);
            
            CreateTable(
                "dbo.Workers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Image = c.Binary(),
                        Pesel = c.String(),
                        RelianceRating = c.Int(nullable: false),
                        Address_Id = c.Int(),
                        RecruitmentAgency_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.Address_Id)
                .ForeignKey("dbo.RecruitmentAgencies", t => t.RecruitmentAgency_Id)
                .Index(t => t.Address_Id)
                .Index(t => t.RecruitmentAgency_Id);
            
            CreateTable(
                "dbo.RecruitmentAgencies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.Address_Id)
                .Index(t => t.Address_Id);
            
            CreateTable(
                "dbo.TimeSheets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TimeSheetRows",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsPresent = c.Boolean(nullable: false),
                        NumberOfHours = c.Int(nullable: false),
                        IsLate = c.Boolean(nullable: false),
                        Worker_Id = c.Int(),
                        TimeSheet_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Workers", t => t.Worker_Id)
                .ForeignKey("dbo.TimeSheets", t => t.TimeSheet_Id)
                .Index(t => t.Worker_Id)
                .Index(t => t.TimeSheet_Id);

            CreateTable(
                "dbo.AspNetRoles",
                c => new
                {
                    Id = c.String(nullable: false, maxLength: 128),
                    Name = c.String(nullable: false, maxLength: 256),
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");

            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                {
                    UserId = c.String(nullable: false, maxLength: 128),
                    RoleId = c.String(nullable: false, maxLength: 128),
                })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);

            CreateTable(
                "dbo.AspNetUsers",
                c => new
                {
                    Id = c.String(nullable: false, maxLength: 128),
                    Email = c.String(maxLength: 256),
                    EmailConfirmed = c.Boolean(nullable: false),
                    PasswordHash = c.String(),
                    SecurityStamp = c.String(),
                    PhoneNumber = c.String(),
                    PhoneNumberConfirmed = c.Boolean(nullable: false),
                    TwoFactorEnabled = c.Boolean(nullable: false),
                    LockoutEndDateUtc = c.DateTime(),
                    LockoutEnabled = c.Boolean(nullable: false),
                    AccessFailedCount = c.Int(nullable: false),
                    UserName = c.String(nullable: false, maxLength: 256),
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");

            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    UserId = c.String(nullable: false, maxLength: 128),
                    ClaimType = c.String(),
                    ClaimValue = c.String(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);

            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                {
                    LoginProvider = c.String(nullable: false, maxLength: 128),
                    ProviderKey = c.String(nullable: false, maxLength: 128),
                    UserId = c.String(nullable: false, maxLength: 128),
                })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TimeSheetRows", "TimeSheet_Id", "dbo.TimeSheets");
            DropForeignKey("dbo.TimeSheetRows", "Worker_Id", "dbo.Workers");
            DropForeignKey("dbo.Workers", "RecruitmentAgency_Id", "dbo.RecruitmentAgencies");
            DropForeignKey("dbo.RecruitmentAgencies", "Address_Id", "dbo.Addresses");
            DropForeignKey("dbo.OrderRows", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.Competences", "OrderRow_Id", "dbo.OrderRows");
            DropForeignKey("dbo.OrderRows", "OrderedWorker_Id", "dbo.Workers");
            DropForeignKey("dbo.Competences", "Worker_Id", "dbo.Workers");
            DropForeignKey("dbo.Workers", "Address_Id", "dbo.Addresses");
            DropForeignKey("dbo.AvailabilityPeriods", "OrderRow_Id", "dbo.OrderRows");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropIndex("dbo.TimeSheetRows", new[] { "TimeSheet_Id" });
            DropIndex("dbo.TimeSheetRows", new[] { "Worker_Id" });
            DropIndex("dbo.RecruitmentAgencies", new[] { "Address_Id" });
            DropIndex("dbo.Workers", new[] { "RecruitmentAgency_Id" });
            DropIndex("dbo.Workers", new[] { "Address_Id" });
            DropIndex("dbo.AvailabilityPeriods", new[] { "OrderRow_Id" });
            DropIndex("dbo.OrderRows", new[] { "Order_Id" });
            DropIndex("dbo.OrderRows", new[] { "OrderedWorker_Id" });
            DropIndex("dbo.Competences", new[] { "OrderRow_Id" });
            DropIndex("dbo.Competences", new[] { "Worker_Id" });
            DropTable("dbo.TimeSheetRows");
            DropTable("dbo.TimeSheets");
            DropTable("dbo.RecruitmentAgencies");
            DropTable("dbo.Workers");
            DropTable("dbo.AvailabilityPeriods");
            DropTable("dbo.OrderRows");
            DropTable("dbo.Orders");
            DropTable("dbo.Competences");
            DropTable("dbo.Addresses");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
        }
    }
}
