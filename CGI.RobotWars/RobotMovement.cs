using CGI.RobotWars.Domain;
using CGI.RobotWars.Interface;
using Microsoft.Extensions.Logging;

namespace CGI.RobotWars
{
    public class RobotMovement : IRobotMovement
    {
        private readonly ILogger _logger;

        public RobotMovement(ILoggerFactory logger)
        {
            _logger = logger.CreateLogger<RobotMovement>();
        }

        public void Move(RobotModel robot)
        {
            _logger.LogDebug($"Move Robot in {robot.Direction}, Current Position {robot.XCoordinate} {robot.YCoordinate}");
            switch (robot.Direction)
            {
                case DirectionsEnum.E:
                    if (robot.XCoordinate < robot.Arena.UpperXCoordinate)
                    {
                        robot.XCoordinate++;
                    }

                    break;
                case DirectionsEnum.N:
                    if (robot.YCoordinate < robot.Arena.UpperYCoordinate)
                    {
                        robot.YCoordinate++;
                    }

                    break;
                case DirectionsEnum.S:
                    if (robot.YCoordinate > robot.Arena.LowerYCoordinate)
                    {
                        robot.YCoordinate--;
                    }

                    break;
                case DirectionsEnum.W:
                    if (robot.YCoordinate > robot.Arena.LowerXCoordinate)
                    {
                        robot.XCoordinate--;
                    }

                    break;
            }
            _logger.LogDebug($"Moved Robot in {robot.Direction}, Final Position {robot.XCoordinate} {robot.YCoordinate}");
        }
    }
}