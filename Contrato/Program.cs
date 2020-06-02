using System;
using System.Globalization;
using Contrato.Entities;
using Contrato.Services;

namespace Contrato
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter contract data");
            Console.Write("Number: ");
            int contractNumber = int.Parse(Console.ReadLine());
            Console.Write("Date (dd/MM/yyyy): ");
            DateTime contractDate = DateTime.Parse(Console.ReadLine());
            Console.Write("Contract Value: ");
            double contractValue = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Enter number of Installments: ");
            int months = int.Parse(Console.ReadLine());

            Contract myContract = new Contract(contractNumber, contractDate, contractValue);

            ContractService contractService = new ContractService(new PaypalService);
            contractService.ProcessCotract(myContract, months);

            Console.WriteLine("Installments:");
            foreach(Installment installment in myContract.Installments)
            {
                Console.WriteLine(installment);
            }           

        }
    }
}
