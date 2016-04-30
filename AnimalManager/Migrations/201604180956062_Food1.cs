namespace AnimalManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Food1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FoodTotals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Foodname = c.String(),
                        Foodprice = c.Double(nullable: false),
                        Foodquantity = c.Double(nullable: false),
                        Totalprice = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.FoodTotals");
        }
    }
}
