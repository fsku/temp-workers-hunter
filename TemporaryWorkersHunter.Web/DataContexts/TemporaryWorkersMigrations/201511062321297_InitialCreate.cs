using System.Data.Entity.Migrations;

namespace TemporaryWorkersHunter.Web.DataContexts.TemporaryWorkersMigrations
{
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {

            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
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
                        RecruitmentAgency_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RecruitmentAgencies", t => t.RecruitmentAgency_Id)
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
            DropForeignKey("dbo.AvailabilityPeriods", "OrderRow_Id", "dbo.OrderRows");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");

            DropIndex("dbo.TimeSheetRows", new[] { "TimeSheet_Id" });
            DropIndex("dbo.TimeSheetRows", new[] { "Worker_Id" });
            DropIndex("dbo.RecruitmentAgencies", new[] { "Address_Id" });
            DropIndex("dbo.Workers", new[] { "RecruitmentAgency_Id" });
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

        }
    }
}
