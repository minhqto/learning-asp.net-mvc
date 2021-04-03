namespace Assignment5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TrackWithDetailViewModels",
                c => new
                    {
                        TrackId = c.Int(nullable: false, identity: true),
                        Clerk = c.String(),
                        Composers = c.String(),
                        Genre = c.String(),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.TrackId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TrackWithDetailViewModels");
        }
    }
}
