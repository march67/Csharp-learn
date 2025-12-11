using Morpion;

namespace Morpion.test
{
    public class BoardTests
    {
        [Fact]
        public async Task CheckWinCondition_ValidWinCondition_ReturnTrue()
        {
            // Arrange
            var board = new Board();

            // Act
            var result = board.CheckWinCondition();

            // Assert
            result.Should().BeTrue();

        }
    }
}