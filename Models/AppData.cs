using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CDT.Models
{
	[Table("AppData")]
	public class AppData
	{
		[Key]
		public int ID { get; set; }
		public int ApplicationId { get; set; }
		public string ProjectName { get; set; }
		public string Department { get; set; }
		public string Contact { get; set; }
		public string Email { get; set; }
		public string Address { get; set; }
		public string City { get; set; }
		public string State { get; set; }
		public string Zip { get; set; }
		public string Phone { get; set; }
		public string Fax { get; set; }
		public string Bureau { get; set; }
		public string Programs { get; set; }
		public string Counties { get; set; }
		public string Region { get; set; }
		public string Description { get; set; }
		public string Benefit { get; set; }
		public string Cost { get; set; }
		public string Submitted { get; set; }
		public string LastUpdateUser { get; set; }
		public DateTime LastUpdateDate { get; set; }
	}
}
