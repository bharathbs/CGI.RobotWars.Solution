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
    public class RobotTests
    {
        private Mock<IRobotMovement> _robotMovementMock;
        private Mock<IRobotOrientation> _robotOrientationMock;
        private Mock<ArenaModel> _arenaMock;
        private Robot _robot;

        [TestInitialize]
        public void Setup()
        {
            _robotMovementMock = new Mock<IRobotMovement>();
            _robotOrientationMock = new Mock<IRobotOrientation>();
            _arenaMock = new Mock<ArenaModel>();
            _robot = new Robot(new NullLoggerFactory(), _robotMovementMock.Object, _robotOrientationMock.Object);
            _robot.RobotModel = new RobotModel();
        }

        [TestMethod]
        public void SetRobotCoordinates_SetCoordinates()
        {
            // Arrange
            
            string xCoordinate = "3";
            string yCoordinate = "3";
            DirectionsEnum direction = DirectionsEnum.N;

            // Act
            _robot.SetRobotCoordinate(xCoordinate, yCoordinate, direction, _arenaMock.Object);

            // Assert
            _robot.RobotModel.XCoordinate.Should().Be(3);
            _robot.RobotModel.YCoordinate.Should().Be(3);
            _robot.RobotModel.Direction.Should().Be(DirectionsEnum.N);
            _robot.RobotModel.Arena.Should().Be(_arenaMock.Object);
        }

        [TestMethod]
        public void Move_MovementCommand_InvokesRobotMovement()
        {
            // Act
            _robot.Move("M");

            // Assert
            _robotMovementMock.Verify(r => r.Move(It.IsAny<RobotModel>()), Times.Once);
        }

        [TestMethod]
        public void Move_LeftCommand_InvokesSpinLeft()
        {
            // Act
            _robot.Move("L");

            // Assert
            _robotOrientationMock.Verify(r => r.SpinLeft(It.IsAny<RobotModel>()), Times.Once);
        }

        [TestMethod]
        public void Move_RightCommand_InvokesSpinLeft()
        {
            // Act
            _robot.Move("R");

            // Assert
            _robotOrientationMock.Verify(r => r.SpinRight(It.IsAny<RobotModel>()), Times.Once);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Move_InvalidCommand_ThrowsException()
        {
            // Act
            _robot.Move("AVCAS");
        }
    }
}