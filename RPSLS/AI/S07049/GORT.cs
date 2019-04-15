using System;
using System.Collections.Generic;
using System.Linq;

namespace RPSLS
{
    class GORT : StudentAI
    {
        List<Move> opponentLastMove;
        Move lastMove;
        Move oppMove;
        int count = 0;
        Move myNewMove;
        int iWonLastRound;
        int[] countArray = new int[101];

        public GORT()
        {
            Nickname = "Alphonse le meilleur rat";
            CourseSection = Section.S07049;
            opponentLastMove = new List<Move>();
        }

        public override void Observe(Move opponentMove)
        {
            //opponentLastMove[count++] = (int)opponentMove;
            oppMove = opponentMove;
            //Console.WriteLine($"opponent played {opponentLastMove}");
        }

        public override Move Play()
        {
            count++;
            opponentLastMove.Add(oppMove);

            myNewMove = Modal();

            if (count >= 20)
            {
                AntiMarkov(opponentLastMove); // faire une méthode qui regarde laquelle des IA pourrait gagner contre l'ia contre laquelle je joue
            }

            lastMove = myNewMove;
            //Console.WriteLine($"weird move potentially : {myNewMove}");
            return myNewMove;
        }

        private Move Modal()
        {
            Dictionary<Move, int> mode = new Dictionary<Move, int>();
            foreach (var oppoLastMove in opponentLastMove)
            {
                if (mode.ContainsKey(oppoLastMove))
                {
                    mode[oppoLastMove]++;
                }
                else
                {
                    mode[oppoLastMove] = 1;
                }
            }

            int result = (int)Move.Lizard;
            int max = 0;
            foreach (var key in mode.Keys)
            {
                if (mode[key] > max)
                {
                    //Console.WriteLine("hello, i'm here");
                    max = mode[key];
                    result = (int)key;
                }
            }

            //Console.WriteLine($"i think the mode is:  {(Move)result}");

            return CheckValue((Move)result);
        }

        private Move AntiMarkov(List<Move> oppositionMoves)
        {
            //play against markov : i need three dimensions arrays
            Move[,,] littleMoves = new Move[5,5,5];

            return Move.Lizard;
        }

        Move CheckValue(Move opponentMove)
        {
            Move move = Move.Lizard;
            switch ((int)opponentMove)
            {
                case 0:
                    move = RandomPair(Move.Paper, Move.Spock);
                    break;
                case 1:
                    move = RandomPair(Move.Lizard, Move.Scissors);
                    break;
                case 2:
                    move = RandomPair(Move.Rock, Move.Spock);
                    break;
                case 3:
                    move = RandomPair(Move.Paper, Move.Lizard);
                    break;
                case 4:
                    move = RandomPair(Move.Rock, Move.Scissors);
                    break;
                default:
                    move = RandomPair(Move.Paper, Move.Spock);
                    break;
            }
            return move;
        }

        Move RandomPair(Move move1, Move move2)
        {
            return Game.SeededRandom.NextDouble() < 0.5 ? move1 : move2;
        }   
        
        #region oldAI
        //private void WhatTheHell()
        //{
        //    if (count > 99)
        //    {
        //        //isCircularAI = false;
        //    }
        //    if (opponentLastMove[count] == opponentLastMove[count - 1])
        //    {
        //        DidIWinGenericAI(iWonLastRound, myNewMove);
        //    }
        //    else if (opponentLastMove[count] != opponentLastMove[count - 1] && count >= 5 && opponentLastMove[count] == opponentLastMove[count - 5])
        //    {
        //        //isCircularAI = true;
        //        myNewMove = CheckValue(opponentLastMove[count - 4]);//get the last move played 4 turns ago, to play against that one : four step ahead
        //    }
        //    else if (opponentLastMove[count] != opponentLastMove[count - 2] && count > 2)
        //    {
        //        //Console.WriteLine($"this is a human AI : {myNewMove}");
        //        Random random = Game.SeededRandom;
        //        int random2 = random.Next();
        //        if (random2 > 4)
        //        {
        //            random2 = random.Next(3, 4);
        //        }
        //        else if (random2 < 0)
        //        {
        //            random2 = random.Next(0, 3);
        //        }
        //        myNewMove = CheckValue((Move)random2);
        //    }
        //}
        

        //private void DidIWinGenericAI(int iWonLastRound, Move myNewMove)
        //{
        //    if (iWonLastRound == 1)
        //    {
        //        myNewMove = CheckValue(opponentLastMove[count]);
        //        //Console.WriteLine($"good move : {myNewMove}");
        //    }
        //    //else
        //    //{
        //    //    myNewMove = CheckValue(opponentLastMove[count - 1]);
        //    //}
        //}
#endregion
    }
}
