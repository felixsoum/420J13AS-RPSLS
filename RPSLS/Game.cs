using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSLS
{
    class Game
    {
        Outcome[] outcomes = new Outcome[]
        {
        new Outcome(Move.Rock, Move.Scissors, ""),
        };

        public void Battle(BaseAI ai1, BaseAI ai2)
        {

        }

        public int CompareMoves(Move move1, Move move2)
        {
            return -1;
        }
    }
}
