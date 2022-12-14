using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project_LMSapp1.Models;

namespace Project_LMSapp1.Models
{
    public class LMSDbContext : DbContext
    {
        public LMSDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<LeaveApplication> ApplyLeave { get; set; }
        public DbSet<LoginPage> LoginPage { get; set; }
        public DbSet<Project_LMSapp1.Models.Manager> Manager { get; set; }
       

    }
}
