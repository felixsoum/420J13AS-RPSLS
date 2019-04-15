using System;
using System.Collections.Generic;

namespace RPSLS
{
    class SUNC : StudentAI
    {
        
    int i = 0;
        public const string SonnetXVII = @"
    Who will believe my verse in time to come,
    If it were filled with your most high deserts?
    Though yet heaven knows it is but as a tomb
    Which hides your life, and shows not half your parts.
    If I could write the beauty of your eyes 78,
    And in fresh numbers number all your graces,
    The age to come would say 'This poet lies;
    Such heavenly touches ne'er touched earthly faces.'
    So should my papers, yellowed with their age,
    Be scorned, like old men of less truth than tongue,
    And your true rights be termed a poet's rage
    And stretched metre of an antique song:
    But were some child of yours alive that time,
    You should live twice, in it, and in my rhyme.
    ";
        
        public static List<Move> CreateSequence()
        {
            var list = new List<Move>();
            foreach (char c in SonnetXVII)
            {
                if (c >= 'A' && c <= 'z')
                {
                    list.Add(CharToMove(c));
                }
            }
            return list;
        }
        
        public static Move CharToMove(char c)
        {
            switch (char.ToLower(c))
            {
                case 'e':
                case 'd':
                case 'f':
                case 'b':
                    return Move.Rock;
                case 't':
                case 'h':
                case 'm':
                case 'g':
                case 'x':
                case 'z':
                    return Move.Paper;
                case 'a':
                case 'r':
                case 'u':
                case 'w':
                case 'k':
                case 'j':
                    return Move.Scissors;
                default:
                case 'o':
                case 's':
                case 'l':
                case 'p':
                case 'q':
                    return Move.Spock;
                case 'i':
                case 'n':
                case 'c':
                case 'y':
                case 'v':
                    return Move.Lizard;
            }
        }
        List<Move> sequence;
        int x;
        int index=0;
        int index2=0;
        int index3;
        int count=0;
        
        
        Move result;
        Move? prev = null;
        Move? prevprev = Move.Rock;
        int[,,] history = new int[5, 5, 5];
        int[] history2 = new int[20];
        public SUNC()
        {
            sequence = CreateSequence();
            Nickname = "Chengyu Sun";
            CourseSection = Section.S07248;

        }

        public override Move Play()
        {

            if (!prev.HasValue || i < 19)
            {
                i = i + 1;
                return RandomMove();

            }

             else 
            {
                if (count < 10 && index < sequence.Count - 1)
                {
                    count = 0;
                    index = index2;
                    for (x = 0; x < 19; x++)
                    {
                        if(sequence[index]==(Move)history2[x])
                        {
                            count++;
                        }
                        index++;
                        if(index==19)
                        {
                            index2++;
                        }
                    }
                }


            }
            if (count >10)
                {
                    
                    for (index3 = index2-1 ; index3 < 100; index3++)
                    {
                        if ((int)sequence[index3+i] == 0)
                        {
                            result = Move.Paper;
                        }
                        if ((int)sequence[index3 + i] == 1)
                        {
                            result = Move.Scissors;
                        }
                        if ((int)sequence[index3 + i] == 2)
                        {
                            result = Move.Rock;
                        }
                        if ((int)sequence[index3 + i] == 3)
                        {
                            result = Move.Lizard;
                        }
                       
                        if ((int)sequence[index3+i] == 4)
                        {
                            result = Move.Rock;
                        }
                    }
                }
            else 
            {



                Move bestmove = Move.Lizard;

                int bestcount = -1;
                for (int i = 0; i < 5; i++)
                {
                    int currentcount = history[(int)prevprev, (int)prev, i];

                    if (currentcount > bestcount)
                    {


                        bestmove = (Move)i;
                        bestcount = currentcount;
                    }


                }
                switch (bestmove)
                {
                    default:
                    case Move.Rock:
                    case Move.Scissors:
                        return result = Move.Spock;
                    case Move.Paper:
                    case Move.Lizard:
                        return result = Move.Scissors;
                    case Move.Spock:
                        return result = Move.Lizard;

                }





            }


            return result;




    }
        public override void Observe(Move opponentMove)
        {
            
           if(prev.HasValue&&prevprev.HasValue)
            {
                history[(int)prevprev, (int)prev, (int)opponentMove]++;
            }
            prev = prevprev;
            prevprev = opponentMove;

            history2[i] = (int)opponentMove;
            


        }
    }
}
