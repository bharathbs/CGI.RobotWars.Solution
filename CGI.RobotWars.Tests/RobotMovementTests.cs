using CGI.RobotWars.Domain;
using FluentAssertions;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CGI.RobotWars.Tests
{
    [TestClass]
    public class RobotMovementTests
    {
        private RobotMovement _robotMovement;

        [TestInitialize]
        public void Setup()
        {
            _robotMovement = new RobotMovement(new NullLoggerFactory());
        }

        [TestMethod]
        [DataRow(DirectionsEnum.E, 5, 5, 6,5)]
        [DataRow(DirectionsEnum.N, 5, 5, 5, 6)]
        [DataRow(DirectionsEnum.S, 5, 5, 5, 4)]
        [DataRow(DirectionsEnum.W, 5, 5, 4, 5)]
        public void Move_Direction_UpdatesCoordinates(DirectionsEnum direction, int xCoordinate, int yCoordinate, int expectedXCoordinate, int expectedYCoordinate)
        {
            // Arrange
            RobotModel robotModel = new()
            {
                Arena = new ArenaModel
                {
                    LowerYCoordinate = 0,
                    UpperYCoordinate = 15,
                    LowerXCoordinate = 0,
                    UpperXCoordinate = 15
                },
                Direction = direction,
                XCoordinate = xCoordinate,
                YCoordinate = yCoordinate
            };

            // Act
            _robotMovement.Move(robotModel);

            // Assert
            robotModel.XCoordinate.Should().Be(expectedXCoordinate);
            robotModel.YCoordinate.Should().Be(expectedYCoordinate);

        }

        [TestMethod]
        [DataRow(DirectionsEnum.E, 5, 5)]
        [DataRow(DirectionsEnum.N, 5, 5)]
        [DataRow(DirectionsEnum.S, 0, 0)]
        [DataRow(DirectionsEnum.W, 0, 0)]
        public void Move_OutOfArena_CoordinatesNotUpdated(DirectionsEnum direction, int xCoordinate, int yCoordinate)
        {
            // Arrange
            RobotModel robotModel = new()
            {
                Arena = new ArenaModel
                {
                    LowerYCoordinate = 0,
                    UpperYCoordinate = 5,
                    LowerXCoordinate = 0,
                    UpperXCoordinate = 5
                },
                Direction = direction,
                XCoordinate = xCoordinate,
                YCoordinate = yCoordinate
            };

            // Act
            _robotMovement.Move(robotModel);

            // Assert
            robotModel.XCoordinate.Should().Be(xCoordinate);
            robotModel.YCoordinate.Should().Be(yCoordinate);
        }
    }
}
