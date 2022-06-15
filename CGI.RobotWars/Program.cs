using System;
using CGI.RobotWars.Interface;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CGI.RobotWars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddLogging(builder => builder.AddConsole())
                .AddTransient<IRobotMovement, RobotMovement>()
                .AddTransient<IRobotOrientation, RobotOrientation>()
                .AddTransient<IArena, Arena>()
                .AddTransient<IRobot, Robot>()
                .BuildServiceProvider();

            IArena arena = serviceProvider.GetService<IArena>();

            ILoggerFactory loggerFactory = serviceProvider.GetService<ILoggerFactory>();
            ILogger<Program> logger = loggerFactory!.CreateLogger<Program>();
            logger!.LogInformation($"Arguments : {string.Join(" ", args)}");

            for (int i = 0; i < args.Length; i++)
            {
                switch (args[i])
                {
                    case "ArenaConfiguration":
                        arena!.SetArena(args[i + 1], args[i + 2]);
                        i += 2;
                        break;
                    case "RobotPosition":
                        arena!.ValidateAndCreateRobotPosition(args[i + 1], args[i + 2], args[i + 3]);
                        logger.LogInformation($"Robot : XCoordinate : {args[i + 1]}, YCoordinate : {args[i + 2]}, Direction : {args[i + 3]}");
                        i += 3;
                        break;
                    case "Movement":
                        arena!.MoveRobot(args[i + 1]);
                        i += 1;
                        break;
                    default:
                        logger.LogError( $"Invalid Arguments : {string.Join(" ", args)}");
                        logger.LogError($"Arguments should be like 'ArenaConfiguration 'UpperXAxis' 'UpperYAxis' RobotPosition 'PositionX' 'PositionY' 'Direction' Movement 'MoveCommand'");
                        throw new ArgumentException();
                }
            }
        }
    }
}
