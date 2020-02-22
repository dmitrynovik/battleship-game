using System;
using System.Linq;
using System.Collections.Generic;

namespace BattleshipGame
{

    public class SparseBoard2D : Board2D
    {
        private List<Point2D> _points = new List<Point2D>(0);

        public SparseBoard2D(uint width, uint height) : base(width, height) {  }

        public override IReadOnlyCollection<Point2D> GetPoints() => _points;

        public override bool Add(Piece piece)
        {
            var piecePoints = piece.GetPoints();

            if (_points.Intersect(piecePoints).Any())
            {
                // position occupied, can't add a piece
                return false;                
            }

            _points = _points.Union(piecePoints).ToList();
            return true;
        }

        // See the base Piece class for the Attack method
    }
}
