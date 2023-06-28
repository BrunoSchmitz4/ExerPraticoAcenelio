using System;
using System.Globalization;
using DecSegAplicativo.Entities;
using DecSegAplicativo.Entities.Enums;

namespace DecSegAplicativo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Nome do departamento: ");
            string deptName = Console.ReadLine();
            Console.Write("Insira abaixo os dados do trabalhador: ");
            Console.Write("Nome:");
            string name = Console.ReadLine();
            Console.Write("Senioridade (Junior/Pleno/Sênior): ");
            WorkerLevel level = Enum.Parse<WorkerLevel>(Console.ReadLine());
            Console.WriteLine("Salário Base: ");
            double baseSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Department dept = new Department(deptName);
            Worker worker = new Worker(name, level, baseSalary, dept);

            Console.WriteLine("Quantos contratos para este trabalhador?");
            int n = int.Parse(Console.ReadLine());
            
            for (int i = 1; i <= n; i ++)
            {
                Console.WriteLine($"Emter #{i} contract data: ");
                Console.Write("Date (DD/MM/YYYY(): ");
                DateTime date = DateTime.Parse(Console.ReadLine());
                Console.Write("Value per hour: ");
                double valuePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Duration (hours):");
                int hours = int.Parse(Console.ReadLine());
                HourContract contract = new HourContract(date, valuePerHour, hours);
                worker.addContract(contract);
            }

            Console.WriteLine("\nEnter month and year to calculate income (MM/YYYY): ");
            string monthAndYear = Console.ReadLine();
            int month = int.Parse(monthAndYear.Substring(0, 2));
            int year = int.Parse(monthAndYear.Substring(3));

            Console.WriteLine("Name: " + worker.Name);
            Console.WriteLine("Department: " + worker.Department.Name);
            Console.WriteLine("Income for: " + monthAndYear + ": " + worker.Income(month, year));

        }
    }
}