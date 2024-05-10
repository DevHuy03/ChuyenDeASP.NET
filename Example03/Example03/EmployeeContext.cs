using Example03;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
namespace Example03
{
    public class EmployeeContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SA; Database=Example03;
            User Id=sa; password=macquochuy2003; Trusted_Connection=True; MultipleActiveResultSets=true; 
            Trust Server Certificate=true");
        }
        public DbSet<Employee> Employees { get; set; }
    }
}