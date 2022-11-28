using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using PhoneBook.Api.Commands;
using PhoneBook.Api.Commands.Handlers;
using PhoneBook.Api.Data;

namespace PhoneBook.Api.UnitTest.Commands
{
    [TestFixture]
    public class CreatePersonCommandHandlerTest
    {

        private  Mock<ILogger<CreatePersonCommandHandler>> _loggerMock;
        private PhoneBookContext _DbContextMock;


        
        [SetUp]
        public void Setup()
        {
            _DbContextMock = DbContextHelper.GetDatabaseContext().Result;
            _loggerMock = new();
        }
             


        [Test]
        public async Task Handle_Should_ReturnSuccessResult()
        {
             

            var commmand = new CreatePersonCommand { Company = "", ContactDetails = null, FirstName = "Mehmet", LastName = "Kırmızıkaya" };
            var handler = new CreatePersonCommandHandler(_DbContextMock, _loggerMock.Object);
            var responseData = await handler.Handle(commmand, new System.Threading.CancellationToken());

            //Asserts
            responseData.StatusCode.Equals(200);
            responseData.exceptionMessage.Should().BeNullOrWhiteSpace();

        }

        [Test]
        public async Task Handle_Should_ReturnFailureResult()
        {

            var commmand = new CreatePersonCommand { };
            var handler = new CreatePersonCommandHandler(_DbContextMock, _loggerMock.Object);
            var responseData = await handler.Handle(null, new System.Threading.CancellationToken());

            //Asserts
            responseData.StatusCode.Should().Be(200);

        }

    }
}
