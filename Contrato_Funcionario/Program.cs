using System;
using Contrato_Funcionario.Entities;
using Contrato_Funcionario.Entities.Enums;
using System.Globalization;


namespace Contrato_Funcionario
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter department's name: ");  //Entre com o nome do departamento:
            string depName = Console.ReadLine();
            Console.Write("Enter worker data: ");//Entre com os dados do trabalhador:
            Console.Write("Name: "); //Nome
            string name = Console.ReadLine();
            Console.WriteLine("Level (Junior/MidLevel/Senior): ");  //Nível
            WorkerLevel level = Enum.Parse<WorkerLevel>(Console.ReadLine());
            Console.Write("Base Salary: "); //Salário Base
            double baseSalary = double.Parse(Console.ReadLine(),CultureInfo.InvariantCulture);

            //Instanciando o objeto Department
            Department dept = new Department(depName);

            //Instanciando o objeto Worker
            Worker worker = new Worker(name, level, baseSalary, dept);

            //Quantos contratos para esse trabalhador?
            Console.Write("How many contracts to this worker? ");
            int num = int.Parse(Console.ReadLine());

            for (int i = 1; i <= num; i++)
            {
                Console.WriteLine($"Enter #{i} contract data: ");//Entre com os dados do contrato
                Console.Write("Date (DD/MM/YYYY): "); //Digite a data
                DateTime date = DateTime.Parse(Console.ReadLine());
                Console.Write("Value per hour: ");  //Valor da hora
                double valuePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Duration (hours): ");//Duração
                int hours = int.Parse(Console.ReadLine());
                
                //Instanciando o objeto HourContract                
                HourContract contract = new HourContract(date, valuePerHour, hours);
                worker.AddContract(contract);
            }

            Console.WriteLine();
            //Entre com o mês e ano para calcular o ganho(MM/AAAA) 08/2018
            Console.Write("Enter month and year to calculate income (MM/YYYY) ");
            string monthAndYear = Console.ReadLine(); //mêsEAno
            int month = int.Parse(monthAndYear.Substring(0, 2));
            int year = int.Parse(monthAndYear.Substring(3));
            //Nome
            Console.WriteLine(" Name: " + worker.Name);
            //Departamento
            Console.WriteLine(" Department: " + worker.Department.Name);
            //Ganho
            Console.WriteLine(" Income for " + monthAndYear + ": " + worker.Income(year, month).ToString("F2", CultureInfo.InvariantCulture));

        }
    }
}
