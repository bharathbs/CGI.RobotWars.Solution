using System;
using System.Linq;
using CGI.RobotWars.Interface;
using CommandLine;
using Microsoft.Extensions.DependencyInjection;

namespace CGI.RobotWars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddLogging()
                .AddTransient<IMovementCommand, MovementCommand>()
                .AddTransient<IOrientationCommand, OrientationCommand>()
                .AddTransient<IArena, Arena>()
                .AddTransient<IRobot, Robot>()
                .AddSingleton<ILogger, Logger>()
                .BuildServiceProvider();

            for (int i = 0; i < args.Length; i++)
            {
                switch (args[i])
                {
                    case "ArenaConfiguration" 
                }
            }

        }

        private static void SetArena(ArenaConfiguration arenaConfiguration, ServiceProvider serviceProvider, out IArena arena)
        {
            if (arenaConfiguration.UpperXCoordinate?.Any() != true || arenaConfiguration.UpperYCoordinate?.Any() != true)
            {
                Console.WriteLine("Use ArenaConfiguration --UpperXCoordinate 'upperXCoordinate' --UpperYCoordinate 'upperYCoordinate'");
                arena = null;
                return;
            }

            arena = serviceProvider.GetService<IArena>();

            if (arena != null)
            {
                arena.SetArena(Convert.ToInt32(arenaConfiguration.UpperXCoordinate), Convert.ToInt32(arenaConfiguration.UpperYCoordinate));
            }
        }


        [Verb("RobotPosition", HelpText = "Position of Robot")]
        public class RobotPosition
        {
            [Option("XCoordinate", Required = true)]
            public string UpperXCoordinate { get; set; }

            [Option("YCoordinate", Required = true)]
            public string YCoordinate { get; set; }

            [Option("Orientation", Required = true)]
            public string Orientation { get; set; }
        }


        [Verb("ArenaConfiguration", HelpText = "Enter upper coordinates for Arena")]
        public class ArenaConfiguration
        {
            [Option("UpperXCoordinate", Required = true)]
            public string UpperXCoordinate { get; set; }

            [Option("UpperYCoordinate", Required = true)]
            public string UpperYCoordinate { get; set; }
        }

        [Verb("RobotMovementCommands", HelpText = "Movement instruction for Robot")]
        public class RobotMovementCommands
        {
            [Option("UpperXCoordinate", Required = true)]
            public string UpperXCoordinate { get; set; }

            [Option("UpperYCoordinate", Required = true)]
            public string UpperYCoordinate { get; set; }
        }
    }
}
