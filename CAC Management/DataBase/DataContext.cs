using CAC_Management.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAC_Management.DataBase
{
    public class DataContext : DbContext
    {
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

        public DbSet<Admin> Admin { get; set; }
        public DbSet<Teacher> Teacher { get; set; }
        public DbSet<Student> Student { get; set; }  
        public DbSet<st_routine> student_routine { get; set; }

    }
}
