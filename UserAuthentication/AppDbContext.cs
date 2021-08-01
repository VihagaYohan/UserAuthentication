using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserAuthentication.Model;

namespace UserAuthentication
{
	public class AppDbContext:IdentityDbContext
	{
		public DbSet<Employee> Employees { get; set; }

		public string DbPath { get; private set; }

		public AppDbContext(DbContextOptions<AppDbContext>options):base(options)
		{

		}
	}
}
