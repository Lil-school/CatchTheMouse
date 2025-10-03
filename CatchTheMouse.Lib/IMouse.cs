namespace CatchTheMouse.Lib
{
    public interface IMouse
    {
        Position Position { get; }
        bool IsVisible { get; }
        Position Move();
    }
}