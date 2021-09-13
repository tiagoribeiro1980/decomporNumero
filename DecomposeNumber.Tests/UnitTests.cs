using System;
using DecomposeNumber.API.Controllers;
using DecomposeNumber.API.Domain;
using DecomposeNumber.API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace DecomposeNumber.Tests
{
    public class UnitTests
    {
        private IServiceCollection _services;
        private IServiceProvider _serviceProvider;
        private INumberService _numberService;

        public UnitTests()
        {
            _services = new ServiceCollection();
            _services.AddScoped<INumberService, NumberService>();
            _serviceProvider = _services.BuildServiceProvider();
            _numberService = _serviceProvider.GetRequiredService<INumberService>();
        }
        
        [Fact]
        public async void DecomposeNumberWithInvalidNumber()
        {
            const int number = -5;
            var controller = new NumberController(_numberService);
            var result = await controller.Get(number);
            var badResult = (result as BadRequestObjectResult);

            Assert.IsType<BadRequestObjectResult>(badResult);
        }
        
        [Fact]
        public async void DecomposeNumberWithoutDividerAndPrimeNumbers()
        {
            const int number = 0;
            var controller = new NumberController(_numberService);
            var result = await controller.Get(number);
            var okResult = (result as OkObjectResult);
            var detail = okResult.Value as NumberDetail;
            
            Assert.True(detail.DivisorNumbers.Count == 0 && detail.PrimeNumbers.Count == 0);
        }

        [Fact]
        public async void DecomposeNumberWithDividerAndPrimeNumbers()
        {
            const int number = 45;
            var controller = new NumberController(_numberService);
            var result = await controller.Get(number);
            var okResult = (result as OkObjectResult);
            var detail = okResult.Value as NumberDetail;
            
            Assert.True(detail.DivisorNumbers.Count > 0 && detail.PrimeNumbers.Count > 0);
        }
    }
}