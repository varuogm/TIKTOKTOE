using System;
using System.Collections.Generic;
using System.Text;

namespace tictactoe.Models
{
    public class PlayingPiece
    {

        public PieceType pieceType;

        PlayingPiece(PieceType pieceType)
        {
            this.pieceType = pieceType;
        }
    }

}
