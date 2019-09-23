using Calculator.Domain;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Repository.Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {

        IUserRepository UserRepository { get; }

        Task<int> CompleteAsync();
        ICalculationHistoryRepository CalculationHistoryRepository { get; }
    }
}
