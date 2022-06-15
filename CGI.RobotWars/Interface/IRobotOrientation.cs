using CGI.RobotWars.Domain;

namespace CGI.RobotWars.Interface
{
    public interface IRobotOrientation
    {
        void SpinLeft(RobotModel robotModel);
        void SpinRight(RobotModel robotModel);
    }
}