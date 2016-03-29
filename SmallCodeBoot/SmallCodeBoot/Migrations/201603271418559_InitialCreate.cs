namespace SmallCodeBoot.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Logs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Level = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        Description = c.String(),
                        Exception = c.String(),
                        Ip = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Username = c.String(maxLength: 20),
                        Password = c.String(maxLength: 50),
                        Email = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        Role = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.Logs");
        }
    }
}
