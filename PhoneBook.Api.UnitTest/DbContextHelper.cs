using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using PhoneBook.Api.Data;
 
namespace PhoneBook.Api.UnitTest
{
    public static class DbContextHelper
    {
        public static Task<PhoneBookContext> GetDatabaseContext()
        {
            var options = new DbContextOptionsBuilder<PhoneBookContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                .Options;
            var databaseContext = new PhoneBookContext(options);
            databaseContext.Database.EnsureCreated();
            return Task.FromResult(databaseContext);
        }
    }
}
