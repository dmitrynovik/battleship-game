using System;
using System.Linq;
using System.Collections.Generic;

namespace BattleshipGame
{
    /// <summary>
    /// The sparse 2D game board which is only allocating memory for occupied points.
    /// PROs: allocates very little memory (only for points occupied by pieces)
    /// CONs: stores unordered points, and hence is not good for boards with many pieces as the point search in an unordered collection becomes slow.
    /// </summary>    
    public class SparseBoard2D : Board2D
    {
        private List<Point2D> _points = new List<Point2D>(0);

        public SparseBoard2D(uint width = 10, uint height = 10) : base(width, height) {  }

        public override IReadOnlyCollection<Point2D> GetPoints() => _points;

        protected override bool TryAddImpl(Piece piece)
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
    }
}
