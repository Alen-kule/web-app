namespace Web.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createdatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(maxLength: 256),
                        CityId = c.Int(nullable: false),
                        Address = c.String(maxLength: 256),
                        Contract = c.String(),
                        ContractDateStart = c.DateTime(),
                        ContractDateEnd = c.DateTime(),
                        Phone = c.String(maxLength: 32),
                        Email = c.String(maxLength: 256),
                        ContactPerson = c.String(maxLength: 256),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SifCities", t => t.CityId, cascadeDelete: true)
                .Index(t => t.CompanyName, unique: true)
                .Index(t => t.CityId);
            
            CreateTable(
                "dbo.SifCities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        City = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.InvoiceDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InvoiceId = c.Int(nullable: false),
                        ChargeId = c.Int(nullable: false),
                        Rate = c.Single(nullable: false),
                        Units = c.Int(nullable: false),
                        Amount = c.Single(nullable: false),
                        Tax = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SifCharges", t => t.ChargeId, cascadeDelete: true)
                .ForeignKey("dbo.Invoices", t => t.InvoiceId, cascadeDelete: true)
                .Index(t => t.InvoiceId)
                .Index(t => t.ChargeId);
            
            CreateTable(
                "dbo.SifCharges",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ChargeName = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.ChargeName, unique: true);
            
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InvoiceNumber = c.String(maxLength: 256),
                        InvoiceDate = c.DateTime(nullable: false),
                        StartDate = c.DateTime(),
                        EndDate = c.DateTime(),
                        CompanyName = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.InvoiceNumber, t.CompanyName }, unique: true, name: "InvoiceNumberAndCompanyName");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.InvoiceDetails", "InvoiceId", "dbo.Invoices");
            DropForeignKey("dbo.InvoiceDetails", "ChargeId", "dbo.SifCharges");
            DropForeignKey("dbo.Clients", "CityId", "dbo.SifCities");
            DropIndex("dbo.Invoices", "InvoiceNumberAndCompanyName");
            DropIndex("dbo.SifCharges", new[] { "ChargeName" });
            DropIndex("dbo.InvoiceDetails", new[] { "ChargeId" });
            DropIndex("dbo.InvoiceDetails", new[] { "InvoiceId" });
            DropIndex("dbo.Clients", new[] { "CityId" });
            DropIndex("dbo.Clients", new[] { "CompanyName" });
            DropTable("dbo.Invoices");
            DropTable("dbo.SifCharges");
            DropTable("dbo.InvoiceDetails");
            DropTable("dbo.SifCities");
            DropTable("dbo.Clients");
        }
    }
}
