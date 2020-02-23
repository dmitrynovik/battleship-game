namespace BattleshipGame
{
    public class Point2D
    {
        public Point2D(uint x, uint y, Piece piece = null)
        {
            X = x;
            Y = y;
            Piece = piece;
        }

        public uint X { get; }
        public uint Y { get; }
        public Piece Piece { get; }
        public bool IsHit { get; private set;}

        public void Hit() => IsHit = true;

        public override int GetHashCode() => X.GetHashCode() ^ Y.GetHashCode();

        public override bool Equals(object obj)
        {
            var pt = obj as Point2D;
            return pt != null && pt.X == X && pt.Y == Y;
        }

        public override string ToString() => $"{nameof(Point2D)} ({X},{Y})";
    }
}
