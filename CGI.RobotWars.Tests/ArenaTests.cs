using System;
using CGI.RobotWars.Domain;
using CGI.RobotWars.Interface;
using FluentAssertions;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CGI.RobotWars.Tests
{
    [TestClass]
    public class ArenaTests
    {
        private Mock<IRobot> _robotMock;
        private Arena _arena;

        [TestInitialize]
        public void Setup()
        {
            _robotMock = new Mock<IRobot>();
            _arena = new Arena(_robotMock.Object, new NullLoggerFactory());
        }

        [TestMethod]
        public void SetArena_ValidEntries_SetCoordinates()
        {
            // Arrange
            string upperXCoordinate = "3";
            string upperYCoordinate = "3";

            // Act
            _arena.SetArena(upperXCoordinate, upperYCoordinate);

            // Assert
            _arena.ArenaModel.LowerXCoordinate.Should().Be(0);
            _arena.ArenaModel.LowerYCoordinate.Should().Be(0);
            _arena.ArenaModel.UpperXCoordinate.Should().Be(3);
            _arena.ArenaModel.UpperYCoordinate.Should().Be(3);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void SetArena_InValidEntriesForXCoordinate_ThrowsException()
        {
            // Arrange
            string upperXCoordinate = "n";

            // Act
            _arena.SetArena(upperXCoordinate, "3");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void SetArena_InValidEntriesForYCoordinate_ThrowsException()
        {
            // Arrange
            string upperYCoordinate = "n";

            // Act
            _arena.SetArena( "3", upperYCoordinate);
        }

        [TestMethod]
        public void ValidateAndCreateRobotPosition_ValidEntries_SetRobotCoordinates()
        {
            // Arrange
            string xCoordinate = "3";
            string yCoordinate = "3";
            string direction = "N";

            // Act
            _arena.ValidateAndCreateRobotPosition(xCoordinate, yCoordinate, direction);

            // Assert
            _robotMock.Verify(r => r.SetRobotCoordinate(xCoordinate, yCoordinate, DirectionsEnum.N, It.IsAny<ArenaModel>()), Times.Once);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ValidateAndCreateRobotPosition_InValidEntriesForXCoordinate_ThrowsException()
        {
            // Arrange
            string upperXCoordinate = "n";

            // Act
            _arena.ValidateAndCreateRobotPosition(upperXCoordinate, "3", "E");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ValidateAndCreateRobotPosition__InValidEntriesForYCoordinate_ThrowsException()
        {
            // Arrange
            string upperYCoordinate = "n";

            // Act
            _arena.ValidateAndCreateRobotPosition( "3", upperYCoordinate, "E");
        }

        [TestMethod]
        public void MoveRobot_Invokes_Move()
        {
            // Act
            _arena.MoveRobot("move");

            // Assert
            _robotMock.Verify(r => r.Move(It.IsAny<string>()), Times.Once);
        }
    }
}
