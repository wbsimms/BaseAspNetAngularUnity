using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseAspNetAngularUnity.DataAccess.Models
{
	public class CategoryLog : Entity
	{
		[Key]
		public int CategoryLogId { get; set; }
		public int CategoryId { get; set; }
		public virtual ICollection<Category> Category { get; set; }
		public int LogId { get; set; }
		public Log Log { get; set; }
	}
}
