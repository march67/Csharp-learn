using CsharpLearn.Domain.Entities;

namespace CsharpLearn.Domain.Interfaces;

public interface IWritePlayerRepository
{
    void SaveAsync(Player player);
    void DeleteAsync(Player player);
}