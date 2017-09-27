namespace shubham_1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class s2 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.CustmrMasters");
            AlterColumn("dbo.CustmrMasters", "ID", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.CustmrMasters", "ID");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.CustmrMasters");
            AlterColumn("dbo.CustmrMasters", "ID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.CustmrMasters", "ID");
        }
    }
}
