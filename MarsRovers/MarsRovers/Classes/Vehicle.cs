using MarsRovers.Interfaces;

namespace MarsRovers.Classes
{
    public abstract class Vehicle
    {
        public IGrid Grid { get; set; }
        public IPosition InitialPosition { get; set; }
        public IPosition LastPosition { get; set; }
        public string Instructions { get; set; }
        public bool Status { get; set; }

        protected virtual void MoveForward()
        {
            // Move the Rover only if it will be inside of bounds after that
            switch (LastPosition.Z)
            {
                case 'N':
                    if (LastPosition.Y + 1 <= Grid.LimitY) LastPosition.Y += 1;
                    else Status = false;
                    break;
                case 'E':
                    if (LastPosition.X + 1 <= Grid.LimitX) LastPosition.X += 1;
                    else Status = false;
                    break;
                case 'S':
                    if (LastPosition.Y - 1 >= 0) LastPosition.Y -= 1;
                    else Status = false;
                    break;
                case 'W':
                    if (LastPosition.X - 1 >= 0) LastPosition.X -= 1;
                    else Status = false;
                    break;
            }
        }

        protected virtual void Rotate(char direction)
        {
            // Rotate the Rover based on its current orientation
            switch (LastPosition.Z)
            {
                case 'N':
                    LastPosition.Z = direction == 'L' ? 'W' : 'E';
                    break;
                case 'E':
                    LastPosition.Z = direction == 'L' ? 'N' : 'S';
                    break;
                case 'S':
                    LastPosition.Z = direction == 'L' ? 'E' : 'W';
                    break;
                case 'W':
                    LastPosition.Z = direction == 'L' ? 'S' : 'N';
                    break;
                default:
                    Status = false;
                    break;
            }
        }

        public virtual bool PerformInstruction(char instruction)
        {
            // Check the command to determine the action to perform
            switch (instruction)
            {
                case (char)Commands.MoveForward:
                    MoveForward();
                    break;
                case (char)Commands.RotateLeft:
                case (char)Commands.RotateRight:
                    Rotate(instruction);
                    break;
                default:
                    Status = false;
                    break;

            }
            return Status;
        }
    }

    public enum Commands
    {
        MoveForward = 'M',
        RotateLeft = 'L',
        RotateRight = 'R',
    }
}
