using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Application.UnitTests.Helper;

public static class DbContextHelpers
{
    public static ApplicationDbContext GetApplicationDbContext()
    {
        var optionsBuilder = new DbContextOptionsBuilder();
        optionsBuilder.UseInMemoryDatabase(Guid.NewGuid().ToString());
        var applicationDbContext = new ApplicationDbContext(optionsBuilder.Options);

        return applicationDbContext;
    }
}
