namespace Balloons.Model
{
    public struct Position
    {
        public float X;
        public float Y;

        public Position(float x, float y)
        {
            X = x;
            Y = y;
        }

        public static Position operator +(Position a, Position b)
        {
            return new Position(a.X + b.X, a.Y + b.Y);
        }
    }
}