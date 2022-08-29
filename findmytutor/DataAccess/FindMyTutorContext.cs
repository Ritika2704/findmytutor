using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using findmytutor.Models.Entities;

namespace findmytutor.DataAccess
{
    public class FindMyTutorContext : DbContext
    {

        public FindMyTutorContext() : base("FindMyTutorContext")
        {
        }

        public DbSet<States> States { get; set; }
        public DbSet<cities> cities { get; set; }
        public DbSet<Tutor> tutors { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        //}
    }
}