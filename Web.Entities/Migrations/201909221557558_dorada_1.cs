namespace Web.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dorada_1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.InvoiceDetails", "Amount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.InvoiceDetails", "Amount", c => c.Single(nullable: false));
        }
    }
}
