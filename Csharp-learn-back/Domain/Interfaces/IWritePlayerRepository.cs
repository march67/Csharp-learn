using CsharpLearn.Domain.Entities;

namespace CsharpLearn.Domain.Interfaces;

public interface IWritePlayerRepository
{
    Task SaveAsync(Player player);
    Task DeleteAsync(Player player);
}