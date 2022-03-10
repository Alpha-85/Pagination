using Application.Common.Interfaces;
using Bogus;
using Domain.Models;

namespace Infrastructure.Services;

public sealed class DataFakerService : Faker<Member> , IDataFakerService
{
    public DataFakerService()
    {
        RuleFor(o => o.FirstName, f => f.Name.FirstName());
        RuleFor(o => o.LastName, f => f.Name.LastName());
        RuleFor(o => o.Phone, f => f.Phone.PhoneNumber());
    }
    public Task<IEnumerable<Member>> GenerateMemberData()
    {
        var orderFaker = new DataFakerService();
        var members = orderFaker.GenerateLazy(1000);
            
        return Task.FromResult(members);

    }

}
