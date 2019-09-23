using Calculator.Domain;
using Calculator.Repository.Infrastructure;
using Calculator.Resource;
using System;
using System.Threading.Tasks;
using System.Linq;
using AutoMapper;
using System.Collections.Generic;

namespace Calculator.Service
{
    public interface ICalculationHistoryService
    {
        Task<int> SaveAsync(SumResource sumResource, string result);
        Task<IEnumerable<CalculationHistoryResponse>> GetSummationResult();
        string GetSum(string firstNumber, string secondNumber);
    }
    public class CalculationHistoryService: ICalculationHistoryService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public CalculationHistoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<int> SaveAsync(SumResource sumResource, string result)
        {
            ApplicationUser applicationUser = GetUserForCalculationHistory(sumResource);

            var calculationHistory = new CalculationHistory
            {
                ApplicationUser = applicationUser,
                CalculationDate = DateTime.UtcNow,
                FirstNumber = sumResource.FirstNumber,
                SecondNumber = sumResource.SecondNumber,
                Result = result
            };
            unitOfWork.CalculationHistoryRepository.Add(calculationHistory);
            var completeResult = await unitOfWork.CompleteAsync();
            return completeResult;
        }

        public async Task<IEnumerable<CalculationHistoryResponse>> GetSummationResult()
        {
            var summationResults = await unitOfWork.CalculationHistoryRepository.GetAllAsync(new List<string> { nameof(ApplicationUser) });
            var response = mapper.Map<IEnumerable<CalculationHistory>, IEnumerable<CalculationHistoryResponse>>(summationResults);
            return response;
        }
        private ApplicationUser GetUserForCalculationHistory(SumResource sumResource)
        {
            ApplicationUser applicationUser = null;
            if (!string.IsNullOrEmpty(sumResource.UserName))
            {
                var users = unitOfWork.UserRepository.Find(x => x.UserName == sumResource.UserName);
                if (users.Any())
                {
                    applicationUser = users.First();
                }
                else
                {
                    applicationUser = new ApplicationUser { UserName = sumResource.UserName };
                }
            }
            else
            {
                applicationUser = unitOfWork.UserRepository.GetLastCreatedUser();
            }

            return applicationUser;
        }
        public string GetSum(string firstNumber, string secondNumber)
        {
            string result = string.Empty;
            if (firstNumber.Length > secondNumber.Length)
            {
                string container = firstNumber;
                firstNumber = secondNumber;
                secondNumber = firstNumber;
            }
            var lengthDifference = secondNumber.Length - firstNumber.Length;
            var carry = 0;
            var sum = 0;
            for (var chaPosition = firstNumber.Length - 1; chaPosition >= 0; chaPosition--)
            {
                sum = int.Parse(firstNumber[chaPosition].ToString()) +
                      int.Parse(secondNumber[chaPosition + lengthDifference].ToString()) +
                      carry;
                result = (sum % 10) + result;
                carry = sum / 10;
            }
            for (var charPosition = lengthDifference - 1; charPosition >= 0; charPosition--)
            {
                sum = int.Parse(secondNumber[charPosition].ToString()) + carry;
                result = (sum % 10) + result;
                carry = sum / 10;
            }
            if (carry > 0)
            {
                result = carry + result;
            }
            return result;
        }
    }
}
