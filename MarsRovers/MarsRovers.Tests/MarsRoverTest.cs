using MarsRovers.Classes;
using System;
using Xunit;

namespace MarsRovers.Tests
{
    public class MarsRoverTest
    {
        [Theory]
        // Comentario para explicar tests
        [InlineData(5, 5, 1, 2, 'N', "LMLMLMLMM", 1, 3, 'N', true)]
        [InlineData(5, 5, 3, 3, 'E', "MMRMMRMRRM", 5, 1, 'E', true)]
        [InlineData(3, 2, 1, 1, 'S', "LLMMR", 1, 2, 'N', false)]
        [InlineData(3, 2, 1, 1, 'S', "LLMR", 1, 2, 'E', true)]
        [InlineData(5, 5, 5, 5, 'E', "LLMMMMMLMMMMM", 0, 0, 'S', true)]
        [InlineData(5, 5, 1, 0, 'W', "RRMMMMM", 5, 0, 'E', false)]
        public void MarsRover_ProcessInstructionsTest(int limitX, int limitY, int x, int y, char z, string instructions, int expectedX, int expectedY, char expectedZ, bool expectedStatus)
        {
            MarsRover marsRover = new MarsRover
            {
                InitialPosition = new Position { X = x, Y = y, Z = z },
                LastPosition = new Position { X = x, Y = y, Z = z },
                Grid = new Grid { LimitX = limitX, LimitY = limitY },
                Instructions = instructions,
                Status = true
            };

            foreach(var instruction in instructions.ToCharArray())
            {
                if (!marsRover.ProcessInstruction(instruction)) break;
            }

            // desglosar condicion
            bool lastPositionValid = marsRover.LastPosition.X == expectedX &&
                                     marsRover.LastPosition.Y == expectedY &&
                                     marsRover.LastPosition.Z == expectedZ;
            // 
            Assert.True(lastPositionValid, "Mars Rover's last position does not correspond to expected position");

            // Verifica que cumpla con el estatus esperado
            Assert.True(marsRover.Status == expectedStatus, "Mars Rover's status does not correspond to expected status");
        }
    }
}
