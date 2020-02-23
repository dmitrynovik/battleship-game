using System;
using System.Collections.Generic;
using System.Linq;

namespace BattleshipGame
{
    public abstract class Piece
    {
        public abstract IReadOnlyCollection<Point2D> GetPoints();

        public bool Attack(Point2D point)
        {
            if (point == null)
                throw new ArgumentNullException(nameof(point));

            var pt = GetPoints().FirstOrDefault(p => p.Equals(point));
            pt?.Hit();
            return pt != null;
        }

        public bool Attack(uint x, uint y) => Attack(new Point2D(x, y));

        public Piece Hit(Point2D point)
        {
            Attack(point);
            return this;
        }

        public Piece Hit(uint x, uint y) => Hit(new Point2D(x, y));

        public bool IsDead => GetPoints().All(p => p.IsHit);
    }
}
