using HabitTracker.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HabitTracker.DataAccess;
public class PubContext : DbContext
{
    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }

    public DbSet<User> Users { get; set; }
    public DbSet<Activity> Activitys { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Habit> Habits { get; set; }

    public PubContext()
    {
        
    }
    public PubContext(DbContextOptions<PubContext> options) : base(options)
    {
    }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = PubIntroDatabase");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var UserList = new User[]{
            new User{UserId = 1, Firstname = "Greg", Lastname = "Snyder", EmailAddress = "gsnyder87@gmail.com"},
            new User{UserId = 2, Firstname = "Julie", Lastname = "Jastremski", EmailAddress = "joolyj27@yahoo.com"},
        };
        modelBuilder.Entity<User>().HasData(UserList);

        var Category = new Category[]{
            new Category{CategoryId = 1, Name="Mental"},
            new Category{CategoryId = 2, Name="Physical"},
        };
        modelBuilder.Entity<Category>().HasData(Category);

        var Habits = new Habit[]{
            new Habit{HabitId = 1, Name="Running", CategoryId=2 },
            new Habit{HabitId = 2, Name="Meditation", CategoryId=1 }
        };
        modelBuilder.Entity<Habit>().HasData(Habits);

        var Activities = new Activity[]{
            new Activity{ActivityId = 1, UserId = 1, HabitId = 1, ActivityDate=DateTime.Now},
            new Activity{ActivityId = 2, UserId = 2, HabitId = 2, ActivityDate=DateTime.Now.AddDays(-5)}

        };
        modelBuilder.Entity<Activity>().HasData(Activities);

    }
}