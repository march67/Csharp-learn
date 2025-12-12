using FluentAssertions;
using Morpion;

namespace Morpion.test
{
    public class BoardTests
    {
        [Fact]
        public void CheckWinCondition_ValidDiagonalWinCondition_ReturnTrue()
        {
            // Arrange
            var board = new Board();
            board.InputMoveOnBoard((1, 1, 'X'));
            board.InputMoveOnBoard((2, 2, 'X'));
            board.InputMoveOnBoard((3, 3, 'X'));

            // Act
            var result = board.CheckWinCondition("David");

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void CheckWinCondition_NotValidWinCondition_ReturnFalse()
        {
            // Arrange
            var board = new Board();
            board.InputMoveOnBoard((1, 1, 'X'));
            board.InputMoveOnBoard((2, 2, 'X'));
            board.InputMoveOnBoard((3, 1, 'X'));

            // Act
            var result = board.CheckWinCondition("David");

            // Assert
            result.Should().BeFalse();
        }
    }
}