namespace MyShop.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBasket_Initial : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Baskets", "BasketId", c => c.String());
            AddColumn("dbo.Baskets", "ProductId", c => c.String());
            AddColumn("dbo.Baskets", "Name", c => c.String());
            AddColumn("dbo.Baskets", "Quanity", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Baskets", "Quanity");
            DropColumn("dbo.Baskets", "Name");
            DropColumn("dbo.Baskets", "ProductId");
            DropColumn("dbo.Baskets", "BasketId");
        }
    }
}
