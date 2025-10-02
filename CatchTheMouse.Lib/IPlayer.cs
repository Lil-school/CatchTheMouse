namespace CatchTheMouse.Lib
{
    public interface IPlayer
    {
        Position Position { get; }

        Position Move();
        void Move(Position position);
    }
}