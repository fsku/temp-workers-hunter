using System.Data.Entity.Migrations;

namespace TemporaryWorkersHunter.Web.DataContexts.TemporaryWorkersMigrations
{
    public partial class FieldsBrushup : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Addresses", "Street", c => c.String());
            AddColumn("dbo.Addresses", "Number", c => c.Int(nullable: false));
            AddColumn("dbo.Addresses", "ApartmentNumber", c => c.Int(nullable: false));
            AddColumn("dbo.Addresses", "ZipCode", c => c.String());
            AddColumn("dbo.Workers", "Image", c => c.Binary());
            AddColumn("dbo.Workers", "Pesel", c => c.String());
            AddColumn("dbo.Workers", "RelianceRating", c => c.Int(nullable: false));
            AddColumn("dbo.Workers", "Address_Id", c => c.Int());
            CreateIndex("dbo.Workers", "Address_Id");
            AddForeignKey("dbo.Workers", "Address_Id", "dbo.Addresses", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Workers", "Address_Id", "dbo.Addresses");
            DropIndex("dbo.Workers", new[] { "Address_Id" });
            DropColumn("dbo.Workers", "Address_Id");
            DropColumn("dbo.Workers", "RelianceRating");
            DropColumn("dbo.Workers", "Pesel");
            DropColumn("dbo.Workers", "Image");
            DropColumn("dbo.Addresses", "ZipCode");
            DropColumn("dbo.Addresses", "ApartmentNumber");
            DropColumn("dbo.Addresses", "Number");
            DropColumn("dbo.Addresses", "Street");
        }
    }
}
