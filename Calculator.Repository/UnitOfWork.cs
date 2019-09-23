using Calculator.Domain;
using Calculator.Repository.Infrastructure;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CalculatorDbContext calculatorDbContext;

        public UnitOfWork(CalculatorDbContext calculatorDbContext,
           IUserRepository userRepository,
           ICalculationHistoryRepository calculationHistoryRepository)
        {            
            this.calculatorDbContext = calculatorDbContext;
            UserRepository = userRepository;
            CalculationHistoryRepository = calculationHistoryRepository;
        }

        public IUserRepository UserRepository { get; }
        public ICalculationHistoryRepository CalculationHistoryRepository { get; }

        public async Task<int> CompleteAsync()
        {
            var saveChangeResult = await calculatorDbContext.SaveChangesAsync();
            return saveChangeResult;
        }

        public void Dispose()
        {
            calculatorDbContext.Dispose();
        }
    }
}
