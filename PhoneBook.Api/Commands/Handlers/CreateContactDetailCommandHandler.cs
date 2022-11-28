using MediatR;
using Microsoft.Extensions.Logging;
using PhoneBook.Api.Commands.Response;
using PhoneBook.Api.Data;
using PhoneBook.Api.Events;
using Shared.RabbitMq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


namespace PhoneBook.Api.Commands.Handlers
{
    public class CreateContactDetailCommandHandler : IRequestHandler<CreateContactDetailCommand, ResponseData<ResponseModel>>
    {
        private readonly PhoneBookContext _dbContext;
        private readonly ILogger<CreateContactDetailCommandHandler> _logger;
        
        public CreateContactDetailCommandHandler(PhoneBookContext dbContext,
                                          ILogger<CreateContactDetailCommandHandler> logger)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public async Task<ResponseData<ResponseModel>> Handle(CreateContactDetailCommand command, CancellationToken cancellationToken)
        {

            try
            {
                await _dbContext.ContactDetail.AddAsync(new Data.Entities.ContactDetail
                {
                    Id = command.Id,
                    Value = command.Value,
                    ContactType = command.ContactType,
                    PersonId = command.PersonId
                });

                await _dbContext.SaveChangesAsync();

                _logger.LogInformation($"[Local Transaction] : İletişimDetay Oluşturuldu");
                return ResponseData<ResponseModel>.SendSuccessResponse(new ResponseModel { IsSuccecss = true });

            }
            catch (Exception ex)
            {
                return ResponseData<ResponseModel>.SendErrorResponse(new Exception(ex.Message, ex.InnerException), 500);
            }

        }
    }
}
