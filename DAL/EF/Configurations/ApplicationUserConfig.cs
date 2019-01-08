using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using DAL.Entities;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Configurations
{
	class ApplicationUserConfig : EntityTypeConfiguration<ApplicationUser>
	{
		public ApplicationUserConfig()
		{
			this.HasKey(p => p.Id);
			//this.HasOptional(p => p.Person).WithRequired(p => p.ApplicationUser);
			this.HasOptional(p => p.Person).WithOptionalPrincipal(p => p./*Application*/User);
		}
	}
}
