using MediatR;
using Microsoft.Extensions.Logging;
using PhoneBook.Api.Commands.Response;
using PhoneBook.Api.Data;
using PhoneBook.Api.Data.Entities;
using PhoneBook.Api.Events;
using Shared.RabbitMq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


namespace PhoneBook.Api.Commands.Handlers
{
    public class CreatePersonCommandHandler : IRequestHandler<CreatePersonCommand, ResponseData<ResponseModel>>
    {
        private readonly PhoneBookContext _dbContext;
        private readonly ILogger<CreatePersonCommandHandler> _logger;

        public CreatePersonCommandHandler(PhoneBookContext dbContext,
                                          ILogger<CreatePersonCommandHandler> logger)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public  async Task<ResponseData<ResponseModel>> Handle(CreatePersonCommand command, CancellationToken cancellationToken)
        {
           

            try
            {
               await _dbContext.Persons.AddAsync(new Person
                {
                    Id = command.Id,
                    FirstName = command.FirstName,
                    LastName = command.LastName,
                    Company = command.Company,
                });

                await _dbContext.SaveChangesAsync();

                _logger.LogInformation($"[Local Transaction] : Personel Oluşturuldu.");

                return ResponseData<ResponseModel>.SendSuccessResponse(new ResponseModel { IsSuccecss = true });
            }
            catch (Exception ex)
            {
                return ResponseData<ResponseModel>.SendErrorResponse(new Exception(ex.Message, ex.InnerException), 500);
            }

        }
    }
}
