using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using hb.Business.Types;

namespace hb.Business
{
    public class Vehicle
    {
        public Position Pos { get; private set; }
        public MoveSet Moves { get; private set; }

        public Vehicle(Position pos, MoveSet moves)
        {
            this.Pos = pos ?? throw new ArgumentNullException("pos");
            this.Moves = moves ?? throw new ArgumentNullException("moves");
        }



        public void HandleMoves()
        {
            if (string.IsNullOrEmpty(Moves.Moves))
                throw new ArgumentNullException("moves");
            foreach (var move in Moves.Moves.ToCharArray().Select(m => Enum.Parse<Enums.MoveType>(m.ToString())))
            {
                this.Move(move);
            }
        }

        private void Move(Enums.MoveType move)
        {
            switch (move)
            {
                case Enums.MoveType.L:
                    this.Pos.MoveLeft();
                    break;
                case Enums.MoveType.R:
                    this.Pos.MoveRight();
                    break;
                case Enums.MoveType.M:
                    this.Pos.MoveForward();
                    break;
            }
        }

        public override string ToString()
        {
            return $"{Pos.X}{Pos.Y}{Pos.Direction}";
        }
    }
}
