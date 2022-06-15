namespace CGI.RobotWars.Interface
{
    public interface IArena
    {
        void SetArena(string upperXCoordinate, string upperYCoordinate);
        void ValidateAndCreateRobotPosition(string s, string s1, string s2);
        void MoveRobot(string s);
    }
}