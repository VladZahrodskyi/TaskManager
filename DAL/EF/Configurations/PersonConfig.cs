using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using DAL.Entities;

namespace DAL.EF.Configurations
{
	class PersonConfig:EntityTypeConfiguration<Person>
	{
		public PersonConfig()
		{
			//General Properties
			this.HasKey(i => i.Id);
			this.Property(p => p.Name).HasMaxLength(100).IsRequired();
			this.Property(p => p.Position).HasMaxLength(150).IsRequired();
			this.Property(p => p.Email).HasMaxLength(50).IsRequired();
			//TODO: Reference Properties
			this.HasOptional(t => t.Team).WithMany(p => p.People).HasForeignKey(p=>p.TeamId);
			//this.HasRequired(n => n.ApplicationUser).WithRequiredPrincipal(x => x.Person);//.Map(n=>n.MapKey("ApplicationUserId"));
			 // the best this.HasRequired(t => t.ApplicationUser).WithMany().HasForeignKey(p => p.ApplicationUserId);
																						  //this.HasRequired(t => t.ApplicationUser).WithOptional().Map()HasForeignKey(p => p.ApplicationUserId);


		
}
	}
}
