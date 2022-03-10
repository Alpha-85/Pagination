using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Member> Members { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);

}
