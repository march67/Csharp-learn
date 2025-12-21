using CsharpLearn.Domain.Entities;
using CsharpLearn.Infrastructure.Persistence.Database.Domain.Components.Domain.Entities;

namespace CsharpLearn.Domain.Interfaces;

public interface IReadPlayerRepository
{
    Task<Player> FindByNameAsync(string name);
}