using AutoMapper;
using Calculator.Repository.Infrastructure;
using Calculator.Service;
using Moq;
using System;
using Xunit;

namespace Calculator.UnitTest
{
    public class CalculationHistoryServiceTest
    {
        [Fact]
        public void TestAddNumber()
        {
            //Arrange
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            var mockMapper = new Mock<IMapper>();
            var mockService = new Mock<ICalculationHistoryService>();
            mockService.Setup(s => s.GetSum("111", "222")).Returns("333");
            var service = new CalculationHistoryService(mockUnitOfWork.Object, mockMapper.Object);

            //Act
            var result = service.GetSum("123456789", "987654321");

            //Assert
            Assert.Equal("1111111110", result);
        }
    }
}
