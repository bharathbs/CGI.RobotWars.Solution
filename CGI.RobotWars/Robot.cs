using CGI.RobotWars.Interface;

namespace CGI.RobotWars
{
    public class Robot : IRobot
    {
        private IMovementCommand _movementCommand;
        private IOrientationCommand _orientationCommand;
        private ILogger _logger;

        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }
        public DirectionsEnum Direction { get; set; } 
        public IArena Arena { get; set; }


        public Robot(IMovementCommand movementCommand, IOrientationCommand orientationCommand, ILogger logger)
        {
            _movementCommand = movementCommand;
            _orientationCommand = orientationCommand;
            _logger = logger;
        }

        public Robot CreateRobot(int xCoordinate, int yCoordinate, IArena arena, DirectionsEnum direction)
        {
            XCoordinate = xCoordinate;
            YCoordinate = yCoordinate;
            Direction = direction;
            Arena = arena;

            return this;
        }


    }
}