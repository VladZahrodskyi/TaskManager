namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initialize : DbMigration
    {
		public override void Up()
		{
			CreateTable(
				"dbo.People",
				c => new
				{
					Id = c.Int(nullable: false, identity: true),
					UserId = c.String(maxLength: 128),//changed
					TeamId = c.Int(),
					Name = c.String(nullable: false, maxLength: 100),
					Position = c.String(nullable: false, maxLength: 150),
					Email = c.String(nullable: false, maxLength: 50),
					User_Id = c.String(maxLength: 128),
				})
				.PrimaryKey(t => t.Id)
				.ForeignKey("dbo.Teams", t => t.TeamId)
				.ForeignKey("dbo.ApplicationUsers", t => t.UserId)
				.Index(t => t.TeamId)
				.Index(t => t.UserId);

			CreateTable(
				"dbo.Teams",
				c => new
				{
					Id = c.Int(nullable: false, identity: true),
					TeamName = c.String(maxLength: 50),
				})
				.PrimaryKey(t => t.Id);

			CreateTable(
				"dbo.ApplicationUsers",
				c => new
				{
					Id = c.String(nullable: false, maxLength: 128),
					//PersonId = c.Int(nullable: true),
					Email = c.String(),
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
				.Index(t => t.UserName, unique: true, name: "UserNameIndex");//Login
																			 //.ForeignKey("dbo.People", t => t.PersonId)//added
																			 //.Index(t => t.PersonId);//added

			CreateTable(
				"dbo.AspNetUserClaims",
				c => new
				{
					Id = c.Int(nullable: false, identity: true),
					UserId = c.String(maxLength: 128),//changed
					ClaimType = c.String(),
					ClaimValue = c.String(),
					// ApplicationUser_Id = c.String(maxLength: 128),//deleted
				})
				.PrimaryKey(t => t.Id)
				.ForeignKey("dbo.ApplicationUsers", t => t.UserId)
				.Index(t => t.UserId);

			CreateTable(
				"dbo.AspNetUserLogins",
				c => new
				{
					LoginProvider = c.String(nullable: false, maxLength: 128),
					ProviderKey = c.String(nullable: false, maxLength: 128),
					UserId = c.String(maxLength: 128),
					//ApplicationUser_Id = c.String(maxLength: 128),
				})
				.PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
				.ForeignKey("dbo.ApplicationUsers", t => t.UserId)
				.Index(t => t.UserId);

			CreateTable(
				"dbo.AspNetUserRoles",
				c => new
				{
					UserId = c.String(maxLength: 128),
					RoleId = c.String(nullable: false, maxLength: 128),
					//ApplicationUser_Id = c.String(maxLength: 128),
				})
				.PrimaryKey(t => new { t.UserId, t.RoleId })
				.ForeignKey("dbo.ApplicationUsers", t => t.UserId)
				.ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
				.Index(t => t.RoleId)
				.Index(t => t.UserId);

			CreateTable(
				"dbo.AspNetRoles",
				c => new
				{
					Id = c.String(nullable: false, maxLength: 128),
					Name = c.String(nullable: false, maxLength: 256),
					Discriminator = c.String(nullable: false, maxLength: 128),
				})
				.PrimaryKey(t => t.Id)
				.Index(t => t.Name, unique: true, name: "RoleNameIndex");

			CreateTable(
				"dbo.Status",
				c => new
				{
					Id = c.Int(nullable: false, identity: true),
					Description = c.String(maxLength: 30),
				})
				.PrimaryKey(t => t.Id);

			CreateTable(
				"dbo.TaskDALs",
				c => new
				{
					Id = c.Int(nullable: false),
					ParentId = c.Int(nullable: false),
					Name = c.String(maxLength: 150),
					Comment = c.String(),
					AuthorId = c.Int(nullable: false),
					AssigneeId = c.Int(nullable: false),
					StatusId = c.Int(nullable: false),
					Progress = c.Byte(),
					DateStart = c.DateTime(),
					ETA = c.DateTime(),
					DueDate = c.DateTime(nullable: false),
				})
				.PrimaryKey(t => t.Id)
				//.ForeignKey("dbo.Personå", t => t.Id)
				.ForeignKey("dbo.Status", t => t.StatusId, cascadeDelete: true)
				.ForeignKey("dbo.People", t => t.AuthorId)
				.ForeignKey("dbo.People", t => t.AssigneeId)
				.Index(t => t.Id)
				.Index(t => t.StatusId)
				.Index(t => t.AssigneeId);

		}

		public override void Down()
		{
			DropForeignKey("dbo.TaskDALs", "StatusId", "dbo.Status");
			DropForeignKey("dbo.TaskDALs", "Id", "dbo.People");
			DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
			DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.ApplicationUsers");
			DropForeignKey("dbo.People", "UserId", "dbo.ApplicationUsers");
			DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.ApplicationUsers");
			DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.ApplicationUsers");
			DropForeignKey("dbo.People", "TeamId", "dbo.Teams");
			DropIndex("dbo.TaskDALs", new[] { "StatusId" });
			DropIndex("dbo.TaskDALs", new[] { "Id" });
			DropIndex("dbo.AspNetRoles", "RoleNameIndex");
			DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
			DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
			DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
			DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
			DropIndex("dbo.People", new[] { "UserId" });
			DropIndex("dbo.People", new[] { "TeamId" });
			DropTable("dbo.TaskDALs");
			DropTable("dbo.Status");
			DropTable("dbo.AspNetRoles");
			DropTable("dbo.AspNetUserRoles");
			DropTable("dbo.AspNetUserLogins");
			DropTable("dbo.AspNetUserClaims");
			DropTable("dbo.ApplicationUsers");
			DropTable("dbo.Teams");
			DropTable("dbo.People");
		}
	}
}
