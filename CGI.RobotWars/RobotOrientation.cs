using CGI.RobotWars.Domain;
using CGI.RobotWars.Interface;
using Microsoft.Extensions.Logging;

namespace CGI.RobotWars
{
    public class RobotOrientation : IRobotOrientation
    {
        private readonly ILogger _logger;

        public RobotOrientation(ILoggerFactory logger)
        {
            _logger = logger.CreateLogger<RobotOrientation>();
        }

        public void SpinLeft(RobotModel robotModel)
        {
            _logger.LogDebug($"Spin Left : Current Robot Direction {robotModel.Direction}");

            switch (robotModel.Direction)
            {
                case DirectionsEnum.E:
                    robotModel.Direction = DirectionsEnum.N;
                    break;
                case DirectionsEnum.N:
                    robotModel.Direction = DirectionsEnum.W;
                    break;
                case DirectionsEnum.S:
                    robotModel.Direction = DirectionsEnum.E;
                    break;
                case DirectionsEnum.W:
                    robotModel.Direction = DirectionsEnum.S;
                    break;
            }

            _logger.LogDebug($"Spin Left : Final Robot Direction {robotModel.Direction}");
        }

        public void SpinRight(RobotModel robotModel)
        {
            _logger.LogDebug($"Spin Left : Current Robot Direction {robotModel.Direction}");

            switch (robotModel.Direction)
            {
                case DirectionsEnum.E:
                    robotModel.Direction = DirectionsEnum.S;
                    break;
                case DirectionsEnum.N:
                    robotModel.Direction = DirectionsEnum.E;
                    break;
                case DirectionsEnum.S:
                    robotModel.Direction = DirectionsEnum.W;
                    break;
                case DirectionsEnum.W:
                    robotModel.Direction = DirectionsEnum.N;
                    break;
            }
            _logger.LogDebug($"Spin Left : Final Robot Direction {robotModel.Direction}");
        }
    }
}