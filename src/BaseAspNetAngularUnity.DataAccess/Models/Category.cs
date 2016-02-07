using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseAspNetAngularUnity.DataAccess.Models
{
	public class Category : Entity
	{
		[Key]
		public int CategoryId { get; set; }
		[MaxLength(64)]
		public string CategoryName { get; set; }
	}
}
