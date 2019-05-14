namespace DBContext
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Model;

    public partial class TestingContext : DbContext
    {
        public TestingContext()
            : base("name=TestingContext")
        {
        }

        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<ForgotPassword> ForgotPassword { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().ToTable("dbo.Person");
            modelBuilder.Entity<User>().ToTable("dbo.Users");
            modelBuilder.Entity<ForgotPassword>().ToTable("dbo.ForgotPassword");
            //DbSet<Person>
        }
    }
}
