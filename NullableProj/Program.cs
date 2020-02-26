using System;

namespace NullableProj
{
    public class Employee
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public double? PayRate { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var employee = new Employee()
            {
                FirstName = "John",
                //LastName = "Doe"
            };

            var nameLength = employee.FirstName.Length + employee.LastName?.Length;
            Console.WriteLine($"The employee is called {employee.FirstName} {employee.LastName}");
        }
    }
}
