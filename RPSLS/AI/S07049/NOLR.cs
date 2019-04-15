using System;
using System.Collections.Generic;

namespace RPSLS
{
    class NOLR : StudentAI
    {
        Move nextMove;
        Move beforeMove;
        int countNextMove = 0;
        Move movePrefApres;
        Move monDernierCoup;

        int coupPrefere1;
        int coupPrefere2;
        int coupPrefere3;
        int icoupPrefere1;
        int icoupPrefere2;
        int icoupPrefere3;
        int pointsShakespeare = 0;
        int indexCoupShakespeare;
        int indexCoupFinal = 0;
        int defaite = 0;
        int defaitesSuivis = 0;
        int egauxSuivis = 0;
        int victoire;  
        int victoiresSuivis = 0;
        int egaux = 0;
        
        List<Move> ListAdMoves = new List<Move>();
        List<Move> ListMesMoves = new List<Move>();
        List<Move> ListShakespeare = new List<Move>();
        int[] listCoupPrefere = new int[5];
        Move oppLastMove;
        Move myMove;
        int countMoves = 0;        

        public NOLR()
        {
            Nickname = "MultiFingers";
            CourseSection = Section.S07049;
        }
        public override Move Play()
        {

            rangeListShake();
            if (countMoves < 2)
            {
                myMove = Move.Lizard;
            }
            else
            {
                markovII();                
            }

            return myMove;
        }

        public override void Observe(Move opponentMove)
        {
            oppLastMove = opponentMove;
            ListAdMoves.Add(oppLastMove);
            ListAdMoves[countMoves] = oppLastMove;
            monDernierCoup = myMove;
            resultat();
            if (countMoves > 0)
            {
                beforeMove = ListAdMoves[countMoves - 1];
            }
            countMoves++;
        }

        public void resultat()
        {
            switch (monDernierCoup.CompareWith(oppLastMove))
            {
                default:
                case 0:
                    egaux += 1;
                    egauxSuivis += 1;
                    defaitesSuivis = 0;
                    victoiresSuivis = 0;
                    break;
                case 1:
                    victoire += 1;
                    victoiresSuivis += 1;
                    defaitesSuivis = 0;
                    egauxSuivis = 0;
                    break;
                case -1:
                    defaite += 1;
                    defaitesSuivis += 1;
                    egauxSuivis = 0;
                    victoiresSuivis = 0;
                    break;
            }
        }

        public void markovII()
        {        
            coupPrefere();
            
            int countTemp = 0;
            for(int i = 1; i < ListAdMoves.Count-1; i++)
            {
                if(ListAdMoves[i-1] == beforeMove & oppLastMove == ListAdMoves[i])
                {
                    nextMove = ListAdMoves[i + 1];                    
                    for(int ii = 1; ii<ListAdMoves.Count-1; ii++)
                    {
                        if(ListAdMoves[ii-1] == beforeMove & ListAdMoves[i] == oppLastMove & ListAdMoves[i+1] == nextMove)
                        {
                            countTemp += 1;
                        }
                    }
                    if (countTemp > countNextMove)
                    {
                        movePrefApres = nextMove;                        
                    }
                    myMove = (Move)(((int)nextMove + 1) % 5);
                }                
            }
        }

        public void coupPrefere()
        {
            int countRock = 0;
            int countPaper = 0;
            int countScissors = 0;
            int countSpock = 0;
            int countLizard = 0;
            for (int i = 0; i < countMoves; i++)
            {
                Move temp = ListAdMoves[i];

                switch (temp)
                {
                    case Move.Rock:
                        countRock += 1;
                        break;
                    case Move.Paper:
                        countPaper += 1;
                        break;
                    case Move.Scissors:
                        countScissors += 1;
                        break;
                    case Move.Spock:
                        countSpock += 1;
                        break;
                    case Move.Lizard:
                        countLizard += 1;
                        break;
                }
            }
            listCoupPrefere[0] = countRock;
            listCoupPrefere[1] = countPaper;
            listCoupPrefere[2] = countScissors;
            listCoupPrefere[3] = countSpock;
            listCoupPrefere[4] = countLizard;

            for (int i = 0; i < listCoupPrefere.Length; i++)
            {
                if (listCoupPrefere[i] > coupPrefere1)
                {
                    coupPrefere1 = listCoupPrefere[i];
                    icoupPrefere1 = i;
                }
                if (listCoupPrefere[i] > coupPrefere2 && listCoupPrefere[i] != coupPrefere1)
                {
                    coupPrefere2 = listCoupPrefere[i];
                    icoupPrefere2 = i;
                }
                if (listCoupPrefere[i] > coupPrefere3 && listCoupPrefere[i] != coupPrefere1 && listCoupPrefere[i] != coupPrefere2)
                {
                    coupPrefere3 = listCoupPrefere[i];
                    icoupPrefere3 = i;
                }
            }            
            myChose();
        }

        public void myChose()
        {
            if (icoupPrefere1 == 0 && icoupPrefere2 == 3 || icoupPrefere1 == 3 && icoupPrefere2 == 0)
            {
                myMove = Move.Paper;
            }
            else if (icoupPrefere1 == 2 && icoupPrefere2 == 4 || icoupPrefere1 == 4 && icoupPrefere2 == 2)
            {
                myMove = Move.Rock;
            }
            else if (icoupPrefere1 == 1 && icoupPrefere2 == 4 || icoupPrefere1 == 4 && icoupPrefere2 == 1)
            {
                myMove = Move.Scissors;
            }
            else if (icoupPrefere1 == 0 && icoupPrefere2 == 2 || icoupPrefere1 == 2 && icoupPrefere2 == 0)
            {
                myMove = Move.Spock;
            }
            else if (icoupPrefere1 == 1 && icoupPrefere2 == 3 || icoupPrefere1 == 3 && icoupPrefere2 == 1)
            {
                myMove = Move.Lizard;
            }
            else if (icoupPrefere1 == 0 && icoupPrefere3 == 3 || icoupPrefere1 == 3 && icoupPrefere3 == 0)
            {
                myMove = Move.Paper;
            }
            else if (icoupPrefere1 == 2 && icoupPrefere3 == 4 || icoupPrefere1 == 4 && icoupPrefere3 == 2)
            {
                myMove = Move.Rock;
            }
            else if (icoupPrefere1 == 1 && icoupPrefere3 == 4 || icoupPrefere1 == 4 && icoupPrefere3 == 1)
            {
                myMove = Move.Scissors;
            }
            else if (icoupPrefere1 == 0 && icoupPrefere3 == 2 || icoupPrefere1 == 2 && icoupPrefere3 == 0)
            {
                myMove = Move.Spock;
            }
            else if (icoupPrefere1 == 0 && icoupPrefere3 == 3 || icoupPrefere1 == 3 && icoupPrefere3 == 0)
            {
                myMove = Move.Paper;
            }
            else if (icoupPrefere2 == 2 && icoupPrefere3 == 4 || icoupPrefere2 == 4 && icoupPrefere3 == 2)
            {
                myMove = Move.Rock;
            }
            else if (icoupPrefere2 == 1 && icoupPrefere3 == 4 || icoupPrefere2 == 4 && icoupPrefere3 == 1)
            {
                myMove = Move.Scissors;
            }
            else if (icoupPrefere2 == 0 && icoupPrefere3 == 2 || icoupPrefere2 == 2 && icoupPrefere3 == 0)
            {
                myMove = Move.Spock;
            }
            else if (icoupPrefere2 == 1 && icoupPrefere3 == 3 || icoupPrefere2 == 3 && icoupPrefere3 == 1)
            {
                myMove = Move.Lizard;
            }
            else
            {
                if (oppLastMove == (Move)icoupPrefere1)
                {
                    myMove = (Move)((icoupPrefere2 + 1) % 5);
                }
                else if (oppLastMove == (Move)icoupPrefere2)
                {
                    myMove = (Move)((icoupPrefere3 + 1) % 5);
                }
                else { myMove = (Move)((icoupPrefere1 + 1) % 5); }
            }
        }

        public void shakespeare()
        {
           
            
            for (int ii = 0; ii < ListShakespeare.Count; ii++) // prends l'index des coups joués pour comparer avec le sonnet
            {
                int pointsTest = 0;
                for (int i = 0; i < ListAdMoves.Count; i++) // index pour parcourir le sonnet et comparer les coups
                {                  
                   
                    if (ListAdMoves[i] == ListShakespeare[ii])
                    {
                        pointsTest += 1;
                    }

                    if (defaitesSuivis > 3)
                    {
                        pointsShakespeare = 0;
                    }
                    if (pointsTest > pointsShakespeare)
                    {
                        pointsShakespeare = pointsTest;
                        indexCoupShakespeare = ii; // prends l'index pour utiliser pour mes prochains coups
                        //Console.WriteLine("Points: " + pointsShakespeare);
                        //Console.WriteLine("index list Shake: " + indexCoupShakespeare);
                    }
                }
            }
            
            shakespeareGonnaDie();
        }

        public Move shakespeareGonnaDie()
        {                     
            do
            {
                if (indexCoupFinal > ListShakespeare.Count) // pour éviter overflow
                {
                    indexCoupFinal = 0;
                }
                int tempmove = (int)ListShakespeare[indexCoupFinal];
                tempmove = ((tempmove + 1) % 5);
                myMove = (Move)tempmove; 
                //Console.WriteLine("Mon coup sera: " + myMove);
                indexCoupFinal++;
                return myMove;
            } while (countMoves < 101); // j'ai  fait avec while pour utiliser l'index 
            
        }

        public void rangeListShake()
        {
            foreach (char c in ShakespeareAI.SonnetXVII)
            {
                if (c >= 'A' && c <= 'z')
                {
                    ListShakespeare.Add(ShakespeareAI.CharToMove(c));             
                }
            }
            //for(int i =0; i < ListShakespeare.Count; i++)
            //{
            //    Console.Write(ListShakespeare[i]+" ");
            //    Console.Write(i + " ");
            //}
        }

    }    
}
