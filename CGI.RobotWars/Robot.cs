using System;
using CGI.RobotWars.Domain;
using CGI.RobotWars.Interface;
using Microsoft.Extensions.Logging;

namespace CGI.RobotWars
{
    public class Robot : IRobot
    {
        private readonly ILogger _logger;

        private readonly IRobotMovement _robotMovement;
        private readonly IRobotOrientation _robotOrientation;

        public RobotModel RobotModel { get; set; }

        public Robot(ILoggerFactory logger, IRobotMovement robotMovement, IRobotOrientation robotOrientation)
        {
            _logger = logger.CreateLogger<Robot>();
            _robotMovement = robotMovement;
            _robotOrientation = robotOrientation;
        }

        public void SetRobotCoordinate(string xCoordinate, string yCoordinate, DirectionsEnum direction, ArenaModel arena)
        {
            RobotModel = new RobotModel
            {
                XCoordinate = Convert.ToInt32(xCoordinate),
                YCoordinate = Convert.ToInt32(yCoordinate),
                Direction = direction,
                Arena = arena
            };

            _logger.LogDebug($"SetRobotCoordinate : XCoordinate : {xCoordinate}, YCoordinate : {yCoordinate}, Direction : {direction}");
        }

        public void Move(string moveCommand)
        {
            foreach (char c in moveCommand)
            {
                switch (c)
                {
                    case 'M':
                        _robotMovement.Move(RobotModel);
                        break;
                    case 'L':
                        _robotOrientation.SpinLeft(RobotModel);
                        break;
                    case 'R':
                        _robotOrientation.SpinRight(RobotModel);
                        break;
                    default:
                        _logger.LogError($"Invalid Arguments : {c}");
                        _logger.LogError($"Arguments can be of type 'M', 'L', 'R'");
                        throw new ArgumentOutOfRangeException();
                }
            }

            _logger.LogInformation($"Final Point {RobotModel.XCoordinate}:{RobotModel.YCoordinate} {RobotModel.Direction:G}");
        }
    }
}