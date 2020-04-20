using Contrato_Funcionario.Entities.Enums;
using System.Collections.Generic;

namespace Contrato_Funcionario.Entities
{
    class Worker
    {
        public string Name { get; set; } //[Nome]
        public WorkerLevel Level { get; set; }//[Nível]
        public double BaseSalary { get; set; }//[Salário Básico]
        public Department Department { get; set; }  //Associação do objeto Department

        //Foi usado List, porque um trabalhador pode ter vários contratos
        public List<HourContract> Contracts { get; set; } = new List<HourContract>(); //Associação ao objeto HourContract        

        //Criação dos Construtores
        public Worker()
        {
        
        }
        public Worker(string name, WorkerLevel level, double baseSalary, Department department)
        {
            Name = name;
            Level = level;
            BaseSalary = baseSalary;
            Department = department;
        }
        //o Atributo Contracts, não entrou no construtor, pois lista deve entrar vazia, e sendo preenchida conforme sua necessidade

        //Criação dos Métodos
        public void AddContract(HourContract contract) 
        {
            Contracts.Add(contract);
        }
        public void RemoveContract(HourContract contract)
        {
            Contracts.Remove(contract);
        }

        //Traduzindo algumas plavras, [Income] Ganho, [Year] Ano e [Month] Mês
        public double Income(int year, int month) 
        {

            double sum = BaseSalary;
            foreach (HourContract contract in Contracts)
                if (contract.Date.Year == year && contract.Date.Month == month) 
                {

                    sum += contract.TotalValue();
                }
            return sum;
        }





    }
}
