using Bogus;
using Microsoft.EntityFrameworkCore;
using Test_MVC_EF_01.Data;
using Test_MVC_EF_01.Models;

namespace Test_MVC_EF_01
{
    public class SeedData
    {
        private static Faker? _faker;

        public static async Task InitAsync(ApplicationDbContext context)
        {
            if (await context.Employees.AnyAsync()) return;

            _faker = new Faker("sv");

            IEnumerable<Employee> employees = GenerateEmployees(30);
            await context.AddRangeAsync(employees);

            await context.SaveChangesAsync();
        }


        private static List<Employee> GenerateEmployees(int numberOfEmployees)
        {
            //List<Employee> employees = new List<Employee>();
            List<Employee> employees = [];


            for (int i = 0; i < numberOfEmployees; i++)
            {
                string fName = _faker!.Name.FirstName();
                string lName = _faker.Name.LastName();
                Employee employee = new Employee()
                {
                    FirstName = fName,
                    LastName = lName,
                    Address = _faker.Address.StreetAddress(),
                    ZipCode = _faker.Address.ZipCode(),
                    City = _faker.Address.City(),
                    EmailAddress = _faker.Internet.Email(fName, lName),
                    PhoneNumber = _faker.Phone.PhoneNumber("0##-### ## ##")
                    //PhoneNumber = _faker.Phone.PhoneNumber()
                };
                employees.Add(employee);
            }
            return employees;
        }
    }
}
