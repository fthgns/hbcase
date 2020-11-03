using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace hb.Business.Types
{
    public class MoveSet
    {
        private readonly char[] acceptableMoves = {
            'L', 'R', 'M'
        };
        public string Moves { get; private set; }

        public MoveSet(string moves)
        {
            this.Moves = moves;
        }


        public bool IsValid()
        {
            var moves = this.Moves.ToCharArray();
            return moves.All(p => acceptableMoves.Contains(p));
        }
    }
}
