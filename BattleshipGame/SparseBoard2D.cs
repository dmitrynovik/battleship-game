using System;
using System.Linq;
using System.Collections.Generic;

namespace BattleshipGame
{
    /// <summary>
    /// The sparse 2D game board which is only allocating memory for occupied points.
    /// PROs: 
    /// - allocates very little memory (only for the points occupied by pieces)
    /// - simplicity of implementation (list of points, intersect operation)
    /// CONs: stores unordered points occupied by pieces, 
    ///     and hence is not good for boards with many pieces as addition of a piece will take considerable time (point-by-point comparison)
    /// SHOULD BE USED in the following cases:
    /// - small-sized boards (e.g. 10x10)
    /// - sparse boards (the board is large but the pieces are not many)
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
