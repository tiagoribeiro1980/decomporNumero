using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DecomposeNumber.API.Domain;
using Microsoft.AspNetCore.Mvc;

namespace DecomposeNumber.API.Services
{
    public interface INumberService
    {
        Task<IActionResult> GetDetails(int number);
    }
    
    public class NumberService : INumberService
    {
        public async Task<IActionResult> GetDetails(int number)
        {
            try
            {
                if (number < 0)
                    return new BadRequestObjectResult(new {message = "Informe um número maior que zero."});
                
                return new OkObjectResult(DecomposeNumber(number));
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(new
                    {message = "Ocorreu um erro ao decompor o número informado. Erro: " + ex.Message});
            }
        }

        private static NumberDetail DecomposeNumber(int number)
        {
            var divisorNumbersList = new List<int>();
            var primeNumbersList = new List<int>();

            for (var i = 1; i <= number; i++)
            {
                if (!IsDivisor(number, i)) continue;
                
                divisorNumbersList.Add(i);
                if (IsPrime(i))
                    primeNumbersList.Add(i);
            }

            var response = new NumberDetail()
            {
                Number = number,
                DivisorNumbers = divisorNumbersList,
                PrimeNumbers = primeNumbersList
            };

            return response;
        }

        private static bool IsDivisor(int originalNumber, int divisor)
        {
            return (originalNumber % divisor == 0);
        }

        private static bool IsPrime(int number)
        {
            var count = 0;
            for (var i = number; i > 0; i--)
            {
                if (number % i == 0)
                    count++;
                
                if (count > 2)
                    return false;
            }

            return true;
        }

    }
}