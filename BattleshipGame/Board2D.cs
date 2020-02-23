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

        public bool TryAdd(Piece piece)
        {
            if (piece.GetPoints().Any(p => p.X >= Width || p.Y >= Height))
            {
                // out of bounds:
                return false;
            }

            return TryAddImpl(piece);
        }

        public Board2D Add(Piece piece)
        {
            TryAdd(piece);
            return this;
        }

        protected abstract bool TryAddImpl(Piece piece);

        public bool IsGameLost => IsDead;

        public override string ToString() => $"{GetType()} {Width}x{Height}";
    }
}
