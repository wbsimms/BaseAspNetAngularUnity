using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseAspNetAngularUnity.DataAccess.Models
{
	public class Log : Entity
	{
		[Key]
		public int LogId { get; set; }
		public int EventId { get; set; }
		public int Priority { get; set; }
		[MaxLength(32)]
		public string Severity { get; set; }
		[MaxLength(256)]
		public string Title { get; set; }
		public DateTime Timestamp { get; set; }
		[MaxLength(32)]
		public string MachineName { get; set; }
		[MaxLength(512)]
		public string AppDomainName { get; set; }
		[MaxLength(256)]
		public string ProcessId { get; set; }
		[MaxLength(512)]
		public string ProcessName { get; set; }
		[MaxLength(512)]
		public string ThreadName { get; set; }
		[MaxLength(128)]
		public string Win32ThreadId { get; set; }
		[MaxLength(1500)]
		public string Message { get; set; }
		[DataType(DataType.Text)]
		public string FormattedMessage { get; set; }

	}
}
