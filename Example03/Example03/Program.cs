using Example03;
using System.Collections.Generic;
using System;

namespace Example03

{

    class Program
    {
        static void Main(string[] args)
        {
            EmployeeContext context = new EmployeeContext();
            Employee em = new Employee();
            em.FirstName = "tu";
            em.LastName = "Nguyen";
            em.EmailId = " info@nguyen anh tu.com ";
            context.Employees.Add(em);
            context.SaveChanges();
            em = new Employee();
            em.FirstName = "Phat";
            em.LastName = "Huynh";
            em.EmailId = "info@huynhtanphat .com";
            context.Employees.Add(em);
            context.SaveChanges();

            Console.WriteLine("---- Loading all data-----");
            List<Employee> employeesA = context.Employees.ToList();
            foreach (Employee empA in employeesA)
            {
                Console.WriteLine(empA.FirstName);
                Console.WriteLine(empA.LastName);
                Console.WriteLine(empA.EmailId);
            }
            Console.WriteLine("---- Loading a single entity ----- ");
            Employee empB = context.Employees.Single(b => b.Id == 1);
            Console.WriteLine(empB.FirstName);
            Console.WriteLine(empB.EmailId);
            Console.WriteLine("-----Loading with Filtering-----");
            List<Employee> employeesB = context.Employees
            .Where(b => b.FirstName.Contains("Tu"))
            .ToList();
            foreach (Employee empC in employeesB)
            {
                Console.WriteLine(empC.FirstName);
                Console.WriteLine(empC.LastName);
                Console.WriteLine(empC.EmailId);

            }
        }
    }
}