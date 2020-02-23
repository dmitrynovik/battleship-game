using System;
using System.Collections.Generic;
using System.Linq;

namespace BattleshipGame
{
    public class Ship : Piece
    {
        private readonly Point2D[] _points;

        public Ship(uint x, uint y, Direction orientation, uint size)
        {
            if (size <= 0)
                throw new ArgumentException("Size must be a positive number", nameof(size));

            Size = size;
            Orientation = orientation;

            _points =  Enumerable.Range(0, Convert.ToInt32(Size))
                .Select(n => Orientation == Direction.Horizontal ?
                    new Point2D((uint)(x + n), (uint)y, this) :
                    new Point2D((uint)x, (uint)(y + n), this)
                )
                .ToArray();
        }

        public uint Size { get; }
        public Direction Orientation { get ;}

        public override IReadOnlyCollection<Point2D> GetPoints() => _points;
    }
}
