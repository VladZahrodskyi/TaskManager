using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using DAL.Entities;
namespace DAL.EF.Configurations
{
	class TeamConfig : EntityTypeConfiguration<Team>
	{
		public TeamConfig()
		{
			//General Properties
			this.HasKey(i => i.Id);
			this.Property(p => p.TeamName).HasMaxLength(50);
			//TODO: Reference Properties
		}
	}
}
