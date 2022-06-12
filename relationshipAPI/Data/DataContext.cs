using Microsoft.EntityFrameworkCore;
using relationshipAPI.Model;
using relationshipAPI.Model.One_TO_many;
using relationshipAPI.Model.One_TO_One;

namespace relationshipAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<User> users { get; set; } 
        public DbSet<Charecter> Charecters { get; set; }
        public DbSet<weapon> weapons { get; set; }
        public DbSet<Skills> Skillls { get; set; }

        //One to Many

        public DbSet<Blog12M> Blog12Ms { get; set; }
        public DbSet<Post> Posts { get; set; }



        //ONE TO ONE

        public DbSet<Blogtype> blogtypes { get; set; }
        public DbSet<Blog> blogs { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Blog>()
                .HasOne(b => b.Blogtypes)
                .WithOne(i => i.Blogs);
              
        }







    }
}
