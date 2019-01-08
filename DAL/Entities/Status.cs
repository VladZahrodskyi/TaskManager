using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
	public class Status
	{
		//[Key]
		public int Id { get; set; }
		//Tells the status
		public string Description { get; set; }

		public virtual ICollection<TaskDAL> Tasks { get; set; }

		public Status()
		{
			Tasks = new List<TaskDAL>();
		}
	}
}
