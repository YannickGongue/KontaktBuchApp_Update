using KontaktBuchApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KontaktBuchApp.DBManager
{
	public class DbContactContext : DbContext
	{
		public DbContactContext(DbContextOptions<DbContactContext> options) : base(options)
		{
		}
		public DbSet<MContact> Contacts { get; set; }
		public DbSet<MAddress> Addresses { get; set; }	
		public DbSet<MContactMethod> ContactMethods { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			//Configure domain classes using modelBuilder here.

			modelBuilder.Entity<MContactMethod>()
				  .HasOne<MContact>(c => c.mContact)
				  .WithMany(sp => sp.ContactMethods)
				  .HasForeignKey(s => s.ContactId);


			modelBuilder.Entity<MContact>()
				 .HasKey(ad => ad.ContactId);

			modelBuilder.Entity<MAddress>()
				 .HasOne(st => st.mContact)
				 .WithMany(u => u.Addresses)
				 .HasForeignKey(st => st.ContactId);

		}
	}
}
