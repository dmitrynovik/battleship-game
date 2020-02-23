using System.Linq;

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

        public bool Add(Piece piece)
        {
            if (piece.GetPoints().Any(p => p.X >= Width || p.Y >= Height))
            {
                // out of bounds:
                return false;
            }

            return AddImpl(piece);
        }

        protected abstract bool AddImpl(Piece piece);

        public bool IsGameLost => IsDead;

        public override string ToString() => $"{GetType()} {Width}x{Height}";
    }
}
