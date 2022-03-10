using Domain.Models;

namespace Application.Common.Interfaces;

public interface IDataFakerService
{
    Task<IEnumerable<Member>> GenerateMemberData();

}
