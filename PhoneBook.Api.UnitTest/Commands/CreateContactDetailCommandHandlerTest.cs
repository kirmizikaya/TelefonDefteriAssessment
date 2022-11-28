using FluentAssertions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using PhoneBook.Api.Commands;
using PhoneBook.Api.Commands.Handlers;
using PhoneBook.Api.Controllers;
using PhoneBook.Api.Data;
using PhoneBook.Api.Data.Entities;

namespace PhoneBook.Api.UnitTest.Commands
{
    [TestFixture]
    public class CreateContactDetailCommandHandlerTest
    {
       

        private  Mock<ILogger<CreateContactDetailCommandHandler>> _loggerMock;
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


            var commmand = new CreateContactDetailCommand { ContactType = ContactType.Email, PersonId = new Guid(), Value= "Test Value"  };
            var handler = new CreateContactDetailCommandHandler(_DbContextMock, _loggerMock.Object);
            var responseData = await handler.Handle(commmand, new System.Threading.CancellationToken());

            //Asserts
            responseData.StatusCode.Equals(200);
            responseData.exceptionMessage.Should().BeNullOrWhiteSpace();

        }

        [Test]
        public async Task Handle_Should_ReturnFailureResult()
        {

            var commmand = new CreateContactDetailCommand { };
            var handler = new CreateContactDetailCommandHandler(_DbContextMock, _loggerMock.Object);
            var responseData = await handler.Handle(null, new System.Threading.CancellationToken());

            //Asserts
            responseData.StatusCode.Should().Be(200);

        }

    }
}
