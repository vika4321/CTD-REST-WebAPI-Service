using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CDT.Models;

namespace CDT.Accessor
{
	public class CDTData : DbContext
	{
		public CDTData(DbContextOptions<CDTData> options)
		: base(options)
		{ }

		public DbSet<AppData> AppData { get; set; }

		public DbSet<ProjectData> ProjectData { get; set; }

	}
}
