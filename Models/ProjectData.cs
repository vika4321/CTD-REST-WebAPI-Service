using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CDT.Models
{
	[Table("ProjectData")]
	public class ProjectData
	{
		[Key]
		public int ID { get; set; }
		public int ApplicationId { get; set; }
		public string ProjectType { get; set; }
		public string LastUpdateUser { get; set; }
		public DateTime LastUpdateDate { get; set; }
	}
}
