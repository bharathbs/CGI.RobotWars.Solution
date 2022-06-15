using System;
using CGI.RobotWars.Domain;
using CGI.RobotWars.Interface;
using Microsoft.Extensions.Logging;

namespace CGI.RobotWars
{
    public class Arena : IArena
    {
        private readonly IRobot _robot;
        private readonly ILogger _logger;
        public ArenaModel ArenaModel { get; set; }

        public Arena(IRobot robot, ILoggerFactory logger)
        {
            _robot = robot;
            _logger = logger.CreateLogger<Arena>();
        }

        public void SetArena(string upperXCoordinate, string upperYCoordinate)
        {
            Validate(upperXCoordinate, upperYCoordinate, true);

            ArenaModel = new ArenaModel
            {
                UpperXCoordinate = Convert.ToInt32(upperXCoordinate),
                UpperYCoordinate = Convert.ToInt32(upperYCoordinate),
                LowerXCoordinate = 0,
                LowerYCoordinate = 0
            };

            _logger.LogDebug($"SetArena : UpperXCoordinate : {ArenaModel.UpperXCoordinate}, UpperYCoordinate : {ArenaModel.UpperYCoordinate}, LowerXCoordinate : {ArenaModel.LowerXCoordinate}, LowerYCoordinate : {ArenaModel.LowerYCoordinate}");
        }

        private void Validate(string xCoordinate, string yCoordinate, bool isArena)
        {
            string error;
            if (!int.TryParse(xCoordinate, out _))
            {
                error = string.Join("X Coordinate is invalid for", isArena ? "Arena" : "Robot");
                _logger.LogError(error);
                throw new ArgumentOutOfRangeException(error);
            }

            if (!int.TryParse(yCoordinate, out _))
            {
                error = string.Join("Y Coordinate is invalid for", (isArena ? "Arena" : "Robot"));

                _logger.LogError(error);
                throw new ArgumentOutOfRangeException(error);
            }
        }

        public void ValidateAndCreateRobotPosition(string xCoordinate, string yCoordinate, string direction)
        {
            Validate(xCoordinate, yCoordinate, false);

            if (Enum.TryParse(direction, true, out DirectionsEnum directionEnum))
            {
                _robot.SetRobotCoordinate(xCoordinate, yCoordinate, directionEnum, ArenaModel);
            }
            else
            {
                _logger.LogError($"Invalid Direction : {direction}");
                throw new ArgumentOutOfRangeException($"Invalid Direction : {direction}");
            }
        }

        public void MoveRobot(string s) => _robot.Move(s);
    }
}
