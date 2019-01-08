using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using DAL.Entities;
namespace DAL.EF.Configurations
{
	class TaskDALConfig : EntityTypeConfiguration<TaskDAL>
	{
		public TaskDALConfig()
		{
			//General Properties
			this.HasKey(i => i.Id);
			this.Property(p => p.Name).HasMaxLength(150);
			this.Property(p => p.Comment).IsVariableLength();

			//TODO: Reference Properties
			this.HasRequired(p => p.Author)
				.WithRequiredDependent()	//Delete
				.WillCascadeOnDelete(false);//Delete
			this.HasRequired(p => p.Assignee)
				.WithRequiredDependent()	//Delete
				.WillCascadeOnDelete(false);//Delete

			this.HasRequired(s => s.Status)
				.WithMany(t => t.Tasks)
				.HasForeignKey(k => k.StatusId);

		}
	}
}
