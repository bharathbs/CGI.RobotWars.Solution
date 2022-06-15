using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CGI.RobotWars.Domain;
using CGI.RobotWars.Interface;
using FluentAssertions;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CGI.RobotWars.Tests
{
    [TestClass]
    public class RobotOrientationTests
    {
        private IRobotOrientation _robotOrientation;

        [TestInitialize]
        public void Setup()
        {
            _robotOrientation = new RobotOrientation(new NullLoggerFactory());
        }

        [TestMethod]
        [DataRow(DirectionsEnum.E, DirectionsEnum.N)]
        [DataRow(DirectionsEnum.N, DirectionsEnum.W)]
        [DataRow(DirectionsEnum.W, DirectionsEnum.S)]
        [DataRow(DirectionsEnum.S, DirectionsEnum.E)]

        public void SpinLeft_Changes_RobotDirection(DirectionsEnum direction, DirectionsEnum expectedDirection)
        {
            // Arrange
            RobotModel robotModel = new()
            {
                Direction = direction,
            };

            // Act
            _robotOrientation.SpinLeft(robotModel);

            // Assert
            robotModel.Direction.Should().Be(expectedDirection);
        }

        [TestMethod]
        [DataRow(DirectionsEnum.E, DirectionsEnum.S)]
        [DataRow(DirectionsEnum.N, DirectionsEnum.E)]
        [DataRow(DirectionsEnum.W, DirectionsEnum.N)]
        [DataRow(DirectionsEnum.S, DirectionsEnum.W)]

        public void SpinRight_Changes_RobotDirection(DirectionsEnum direction, DirectionsEnum expectedDirection)
        {
            // Arrange
            RobotModel robotModel = new()
            {
                Direction = direction,
            };

            // Act
            _robotOrientation.SpinRight(robotModel);

            // Assert
            robotModel.Direction.Should().Be(expectedDirection);
        }
    }
}
