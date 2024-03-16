
using Microsoft.EntityFrameworkCore;

namespace TicketApp.Areas.IssueTicket.Models
{
    public class IssueContext : DbContext
    {
        public IssueContext(DbContextOptions<IssueContext> options) : base(options)
        {
        }

        public DbSet<Issue> Issues { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Priority> Priorities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Status>().HasData(
                    new Status { StatusID = "1", StatusName = "Open" },
                    new Status { StatusID = "2", StatusName = "In Progress" },
                    new Status { StatusID = "3", StatusName = "Closed" },
                    new Status { StatusID = "4", StatusName = "Resolved" }
            );

            modelBuilder.Entity<Priority>().HasData(
                    new Priority { PriorityID = "1", PriorityName = "Low" },
                    new Priority { PriorityID = "2", PriorityName = "Medium" },
                    new Priority { PriorityID = "3", PriorityName = "High" },
                    new Priority { PriorityID = "4", PriorityName = "Critical" }
            );

            modelBuilder.Entity<Issue>().HasData(
                    new Issue
                        {
                            TicketID = 1,
                            ticketTitle = "Can't log in",
                            ticketDescription = "I can't log in to my account",
                            ticketName = "John Doe",
                            ticketEmail = "johndoe@mail.com",
                            submitDate = DateTime.Parse("2024-01-01"),
                            priorityID = "3",
                            statusID = "1"
                        },
                    new Issue
                    {
                            TicketID = 2,
                            ticketTitle = "Can't access my email",
                            ticketDescription = "I can't access my email",
                            ticketName = "Jane Doe",
                            ticketEmail = "janedoe@mail.com",
                            submitDate = DateTime.Parse("2024-01-02"),
                            priorityID = "2",
                            statusID = "2"
                    },
                    new Issue
                    {
                            TicketID = 3,
                            ticketTitle = "Password Reset",
                            ticketDescription = "I need to reset my password",
                            ticketName = "Michael Man",
                            ticketEmail = "manmichael@mail.com",
                            submitDate = DateTime.Parse("2024-01-03"),
                            priorityID = "3",
                            statusID = "3"  
                    }
            );
        }
    }
}
