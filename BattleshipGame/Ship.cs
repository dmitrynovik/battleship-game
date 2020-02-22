using System;
using System.Collections.Generic;
using System.Linq;

namespace BattleshipGame
{
    public class Ship : Piece
    {
        public enum Direction { Horizontal, Vertical }

        private readonly Point2D[] _points;

        public Ship(Point2D topLeft, Direction orientation, uint size)
        {
            if (size <= 0)
                throw new ArgumentException("Size must be a positive number", nameof(size));

            TopLeft = topLeft;
            Size = size;
            Orientation = orientation;

            _points =  Enumerable.Range(0, Convert.ToInt32(Size))
                .Cast<uint>()
                .Select(n => Orientation == Direction.Horizontal ?
                    new Point2D(TopLeft.X + n, TopLeft.Y, this) :
                    new Point2D(TopLeft.X, TopLeft.Y + n, this)
                )
                .ToArray();
        }

        public Point2D TopLeft { get; }
        public uint Size { get; }
        public Direction Orientation { get ;}

        public override IReadOnlyCollection<Point2D> GetPoints() => _points;
    }
}
