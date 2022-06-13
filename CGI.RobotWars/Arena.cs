using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CGI.RobotWars.Interface;

namespace CGI.RobotWars
{
    public class Arena : IArena
    {
        public int UpperXCoordinate { get; set; }
        public int UpperYCoordinate { get; set; }

        public int LowerXCoordinate { get; set; }

        public int LowerYCoordinate { get; set; }

        public void SetArena(int upperXCoordinate, int upperYCoordinate)
        {
            UpperXCoordinate = upperXCoordinate;
            UpperYCoordinate = upperYCoordinate;
            LowerXCoordinate = 0;
            LowerYCoordinate = 0;
        }
    }
}
