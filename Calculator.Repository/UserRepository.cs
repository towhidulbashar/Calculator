using Calculator.Domain;
using Calculator.Repository.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calculator.Repository
{
    public class UserRepository : Repository<ApplicationUser>, IUserRepository
    {
        public UserRepository(CalculatorDbContext calculatorDbContext) : base(calculatorDbContext)
        {
        }

        public ApplicationUser GetLastCreatedUser()
        {
            return entities
                .OrderByDescending(x => x.DateCreated)
                .FirstOrDefault();
        }
    }
}
