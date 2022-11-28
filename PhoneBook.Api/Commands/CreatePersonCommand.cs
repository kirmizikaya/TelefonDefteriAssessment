using MediatR;
using PhoneBook.Api.Commands.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Api.Commands
{
    public class CreatePersonCommand : IRequest<ResponseData<ResponseModel>>
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }

        public IList<CreateContactDetailCommand> ContactDetails { get;  set; }
        public CreatePersonCommand()
        {
            Id = Guid.NewGuid();
        }
    }
}
