using Calculator.Domain;
using Calculator.Repository.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.Repository
{
    public class CalculationHistoryRepository : Repository<CalculationHistory>, ICalculationHistoryRepository
    {
        public CalculationHistoryRepository(CalculatorDbContext calculatorDbContext) : base(calculatorDbContext)
        {
        }
    }
}
