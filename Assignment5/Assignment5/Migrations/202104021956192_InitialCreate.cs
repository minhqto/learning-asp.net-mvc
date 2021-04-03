namespace Assignment5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AlbumBaseViewModels",
                c => new
                    {
                        AlbumId = c.Int(nullable: false, identity: true),
                        Coordinator = c.String(),
                        Genre = c.String(),
                        Name = c.String(),
                        ReleaseDate = c.DateTime(nullable: false),
                        UrlAlbum = c.String(),
                    })
                .PrimaryKey(t => t.AlbumId);
            
            CreateTable(
                "dbo.Albums",
                c => new
                    {
                        AlbumId = c.Int(nullable: false, identity: true),
                        Coordinator = c.String(maxLength: 120),
                        Genre = c.String(maxLength: 120),
                        Name = c.String(nullable: false, maxLength: 120),
                        ReleaseDate = c.DateTime(nullable: false),
                        UrlAlbum = c.String(),
                    })
                .PrimaryKey(t => t.AlbumId);
            
            CreateTable(
                "dbo.Artists",
                c => new
                    {
                        ArtistId = c.Int(nullable: false, identity: true),
                        BirthName = c.String(maxLength: 120),
                        BirthOrStartDate = c.DateTime(nullable: false),
                        Executive = c.String(maxLength: 120),
                        Genre = c.String(maxLength: 120),
                        Name = c.String(nullable: false, maxLength: 120),
                        UrlArtist = c.String(),
                    })
                .PrimaryKey(t => t.ArtistId);
            
            CreateTable(
                "dbo.Tracks",
                c => new
                    {
                        TrackId = c.Int(nullable: false, identity: true),
                        Clerk = c.String(maxLength: 120),
                        Composers = c.String(maxLength: 120),
                        Genre = c.String(maxLength: 120),
                        Name = c.String(nullable: false, maxLength: 120),
                    })
                .PrimaryKey(t => t.TrackId);
            
            CreateTable(
                "dbo.ArtistBaseViewModels",
                c => new
                    {
                        ArtistId = c.Int(nullable: false, identity: true),
                        BirthName = c.String(),
                        BirthOrStartDate = c.DateTime(nullable: false),
                        Executive = c.String(),
                        Name = c.String(),
                        UrlArtist = c.String(),
                        Genre = c.String(),
                    })
                .PrimaryKey(t => t.ArtistId);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        GenreId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 120),
                    })
                .PrimaryKey(t => t.GenreId);
            
            CreateTable(
                "dbo.RoleClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
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
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
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
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
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
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.ArtistAlbums",
                c => new
                    {
                        Artist_ArtistId = c.Int(nullable: false),
                        Album_AlbumId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Artist_ArtistId, t.Album_AlbumId })
                .ForeignKey("dbo.Artists", t => t.Artist_ArtistId, cascadeDelete: true)
                .ForeignKey("dbo.Albums", t => t.Album_AlbumId, cascadeDelete: true)
                .Index(t => t.Artist_ArtistId)
                .Index(t => t.Album_AlbumId);
            
            CreateTable(
                "dbo.TrackAlbums",
                c => new
                    {
                        Track_TrackId = c.Int(nullable: false),
                        Album_AlbumId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Track_TrackId, t.Album_AlbumId })
                .ForeignKey("dbo.Tracks", t => t.Track_TrackId, cascadeDelete: true)
                .ForeignKey("dbo.Albums", t => t.Album_AlbumId, cascadeDelete: true)
                .Index(t => t.Track_TrackId)
                .Index(t => t.Album_AlbumId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.TrackAlbums", "Album_AlbumId", "dbo.Albums");
            DropForeignKey("dbo.TrackAlbums", "Track_TrackId", "dbo.Tracks");
            DropForeignKey("dbo.ArtistAlbums", "Album_AlbumId", "dbo.Albums");
            DropForeignKey("dbo.ArtistAlbums", "Artist_ArtistId", "dbo.Artists");
            DropIndex("dbo.TrackAlbums", new[] { "Album_AlbumId" });
            DropIndex("dbo.TrackAlbums", new[] { "Track_TrackId" });
            DropIndex("dbo.ArtistAlbums", new[] { "Album_AlbumId" });
            DropIndex("dbo.ArtistAlbums", new[] { "Artist_ArtistId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropTable("dbo.TrackAlbums");
            DropTable("dbo.ArtistAlbums");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.RoleClaims");
            DropTable("dbo.Genres");
            DropTable("dbo.ArtistBaseViewModels");
            DropTable("dbo.Tracks");
            DropTable("dbo.Artists");
            DropTable("dbo.Albums");
            DropTable("dbo.AlbumBaseViewModels");
        }
    }
}
