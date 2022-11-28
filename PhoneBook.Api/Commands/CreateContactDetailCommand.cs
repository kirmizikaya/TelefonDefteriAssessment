using MediatR;
using PhoneBook.Api.Commands.Response;
using PhoneBook.Api.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Api.Commands
{
    public class CreateContactDetailCommand : IRequest<ResponseData<ResponseModel>>
    {
        public Guid Id { get; set; }
        public ContactType ContactType { get;  set; }
        public string Value { get;  set; }
        public Guid PersonId { get; set; }

        public CreateContactDetailCommand()
        {
            Id = Guid.NewGuid();
        }
    }
}
