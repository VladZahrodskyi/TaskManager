using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
	public class TaskDAL
	{
		//[Key]
		public int Id { get; set; }

		public int ParentId { get; set; }

		public string Name { get; set; }

		public string Comment { get; set; }

		//The person who create this task. ForeignKey to Author
		//[ForeignKey("Author")]
		public int AuthorId { get; set; }

		//The person who GET this task. ForeignKey to Assignee
		//[ForeignKey("Assignee")]
		public int AssigneeId { get; set; }

		//Status of the task 
		//[ForeignKey("Status")]
		public int StatusId { get; set; }

		public byte? Progress { get; set; } //Goes from 0 to 100. Tells About %

		public DateTime? DateStart { get; set; }

		public DateTime? ETA { get; set; }

		public DateTime DueDate { get; set; }


		public virtual Person Assignee { get; set; }
		public virtual Person Author { get; set; }
		public virtual Status Status { get; set; }
	}

}