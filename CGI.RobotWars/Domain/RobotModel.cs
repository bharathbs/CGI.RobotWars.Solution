namespace CGI.RobotWars.Domain
{
    public class RobotModel
    {
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }
        public DirectionsEnum Direction { get; set; }
        public ArenaModel Arena { get; set; }
    }
}