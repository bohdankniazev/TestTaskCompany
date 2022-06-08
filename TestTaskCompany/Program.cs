using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskCompany
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CompanyConfig config = new CompanyConfig();
            Company company = new Company(config);
            company.CreateEmployee("John Smith", "", DateTime.Now.AddYears(-21), Company.JobPosition.Manager);
            company.CreateEmployee("Alex Grem", "John Smith", DateTime.Now.AddYears(-9), Company.JobPosition.Manager);
            company.CreateEmployee("Jina Jerson", "John Smith", DateTime.Now.AddYears(-17), Company.JobPosition.Manager);
            company.CreateEmployee("Bred Philips", "Jina Jerson", DateTime.Now.AddYears(-7), Company.JobPosition.Manager);
            company.CreateEmployee("Gary Oldman", "Jina Jerson", DateTime.Now.AddYears(-9), Company.JobPosition.Manager);
            company.CreateEmployee("Ron", "Gary Oldman", DateTime.Now.AddYears(-3), Company.JobPosition.Employee);
            company.CreateEmployee("Garry", "Gary Oldman", DateTime.Now.AddYears(-15), Company.JobPosition.Employee);

            company.CreateEmployee("Jim", "Bred Philips", DateTime.Now.AddYears(-2), Company.JobPosition.Employee);
            company.CreateEmployee("Dick", "Bred Philips", DateTime.Now.AddYears(-2), Company.JobPosition.Employee);

            company.CreateEmployee("Hew Lory", "John Smith", DateTime.Now.AddYears(-4), Company.JobPosition.Sales);
            company.CreateEmployee("Adam Smith", "Hew Lory", DateTime.Now.AddYears(-4), Company.JobPosition.Sales);
            company.CreateEmployee("Dave", "Adam Smith", DateTime.Now.AddYears(-1), Company.JobPosition.Employee);
            company.CreateEmployee("Carl", "Adam Smith", DateTime.Now.AddYears(-2), Company.JobPosition.Employee);
            company.CreateEmployee("Bob", "Adam Smith", DateTime.Now.AddYears(-3), Company.JobPosition.Employee);


            company.CreateEmployee("Adam Gontier", "Hew Lory", DateTime.Now.AddYears(-3), Company.JobPosition.Sales);

            company.CreateEmployee("Lill Wayne", "Adam Gontier", DateTime.Now.AddYears(-2), Company.JobPosition.Sales);
            company.CreateEmployee("Brus Williams", "Lill Wayne", DateTime.Now.AddYears(-4), Company.JobPosition.Sales);



            //Console.WriteLine(company.FindEmployee("Dave").Salary);
            //Console.WriteLine(company.FindEmployee("Carl").Salary);
            //Console.WriteLine(company.FindEmployee("Bob").Salary);
            //Console.WriteLine(company.FindEmployee("Aran")?.Salary);
            //Console.WriteLine(company.FindEmployee("Garry").Salary);
            //Console.WriteLine(company.FindEmployee("Ron").Salary);
            //Console.WriteLine(company.FindEmployee("Gary Oldman").Salary);

            Console.WriteLine(company.FindEmployee("Adam Gontier").Salary);

            Console.WriteLine(company.SumOfSalaries());
            Console.ReadLine();
        }
    }
}
