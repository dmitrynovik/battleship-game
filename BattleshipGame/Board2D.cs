namespace BattleshipGame
{
    public abstract class Board2D : Piece
    {
        public Board2D(uint width, uint height)
        {
            Height = height;
            Width = width;
        }

        public uint Height { get; }
        public uint Width { get; }  

        public abstract bool Add(Piece piece);

        public bool IsGameLost => IsDead;

        public override string ToString() => $"Board {Width}x{Height}";
    }
}
