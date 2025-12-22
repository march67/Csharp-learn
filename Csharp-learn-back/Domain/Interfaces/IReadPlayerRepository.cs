using CsharpLearn.Domain.Entities;

namespace CsharpLearn.Domain.Interfaces;

public interface IReadPlayerRepository
{
    Task<Player> FindByNameAsync(string name);
}