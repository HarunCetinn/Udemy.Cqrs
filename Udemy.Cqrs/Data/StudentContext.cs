using Microsoft.EntityFrameworkCore;

namespace Udemy.Cqrs.Data
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options) : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(new Student[]
                {
                    new Student() {Name="Harun", Age=23, Surname="Çetin", Id=1},
                    new Student() {Name="Mustafa", Age=19, Surname="Çetin", Id=2},
                });
            base.OnModelCreating(modelBuilder);
        }



    }
}
