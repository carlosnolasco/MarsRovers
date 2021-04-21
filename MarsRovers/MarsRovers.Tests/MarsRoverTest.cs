using MarsRovers.Classes;
using System;
using Xunit;

namespace MarsRovers.Tests
{
    public class MarsRoverTest
    {
        [Theory]
        // Case when Rover will be inside of the bounds with orientation to the North
        [InlineData(5, 5, 1, 2, 'N', "LMLMLMLMM", 1, 3, 'N', true)]

        // Case when Rover will be inside of the bounds with orientation to the East
        [InlineData(5, 5, 3, 3, 'E', "MMRMMRMRRM", 5, 1, 'E', true)]

        // Case when Rover will be inside of the bounds with orientation to the East
        [InlineData(3, 2, 1, 1, 'S', "LLMR", 1, 2, 'E', true)]

        // Case when Rover will be inside of the bounds with orientation to the South
        [InlineData(5, 5, 5, 5, 'E', "LLMMMMMLMMMMM", 0, 0, 'S', true)]

        // Case when Rover will be outside of the bounds
        [InlineData(5, 5, 1, 0, 'W', "RRMMMMM", 5, 0, 'E', false)]

        // Case when Rover will be outside of the bounds
        [InlineData(3, 2, 1, 1, 'S', "LLMMR", 1, 2, 'N', false)]
        public void MarsRover_ProcessInstructionsTest(int limitX, int limitY, int x, int y, char z, string instructions, int expectedX, int expectedY, char expectedZ, bool expectedStatus)
        {
            // Initialize instance of MarsRover to test
            MarsRover marsRover = new MarsRover
            {
                InitialPosition = new Position { X = x, Y = y, Z = z },
                LastPosition = new Position { X = x, Y = y, Z = z },
                Grid = new Grid { LimitX = limitX, LimitY = limitY },
                Instructions = instructions,
                Status = true
            };

            // Iterate through command list
            foreach(var instruction in instructions.ToCharArray())
            {
                // Perform command
                if (!marsRover.PerformInstruction(instruction)) break;
            }

            // Verify that the last X position is equals to the expected result
            bool lastXequalsToExpected = marsRover.LastPosition.X == expectedX;

            // Verify that the last Y position is equals to the expected result
            bool lastYequalsToExpected = marsRover.LastPosition.Y == expectedY;

            // Verify that the last Z orientation is equals to the expected result
            bool lastZequalsToExpected = marsRover.LastPosition.Z == expectedZ;

            // Verify that full position is equal to expected
            bool lastPositionEqualsToExpected = lastXequalsToExpected && lastYequalsToExpected && lastZequalsToExpected;

            // Assert: Initial position must be the same as expected
            Assert.True(lastPositionEqualsToExpected, "Mars Rover's last position does not correspond to expected position");

            // Assert: Status should be the same as expected
            Assert.True(marsRover.Status == expectedStatus, "Mars Rover's status does not correspond to expected status");
        }
    }
}
