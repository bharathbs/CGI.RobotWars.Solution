using CGI.RobotWars.Domain;

namespace CGI.RobotWars.Interface
{
    public interface IRobot
    {
        void SetRobotCoordinate(string xCoordinate, string yCoordinate, DirectionsEnum direction, ArenaModel arena);

        void Move(string moveCommand);
    }
}