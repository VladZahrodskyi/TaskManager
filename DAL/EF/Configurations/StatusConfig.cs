using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using DAL.Entities;
namespace DAL.EF.Configurations
{
	class StatusConfig : EntityTypeConfiguration<Status>
	{
		public StatusConfig()
		{
			//General Properties
			this.HasKey(i => i.Id);
			this.Property(p => p.Description).HasMaxLength(30);
			//TODO: Reference Properties

		}
	}
}
