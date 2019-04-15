using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace RPSLS
{
    class TACS : StudentAI
    {
        int[,] data = new int[5, 5];
        Move? prev = null;

        private class RandomGenerator//Implementing singleton
        {
            private static Random myInstance = null;
            private RandomGenerator() { }

            public static Random GetInstance()
            {
                return myInstance is null ? myInstance = Game.SeededRandom : myInstance;
            }
        }

        private int rockCount, paperCount, scissorsCount, lizardCount, spockCount;
        private int constRock, constPaper, constScissors, constLizard, constSpock;
        private int rockMax, paperMax, scissorMax, lizardMax, spockMax;
        //private double spockMax;
        private int playCount;
        private int upgradeCount;
        private Move playMove, enemy, lastEnemyMove;
        private bool upgradeAI = false;
        private bool spam = false;
        private bool circle = false;
        private bool normal = false;
        private int circleCount;
        private int normalCount = 0;
        private bool check = false;
        private int total;
        private int newCount;
        private bool upgradeRoll = false;

        Random ran = RandomGenerator.GetInstance();//Singleton because AI couldnt fight myself lol

        public TACS()
        {
            Nickname = "TAX";
            CourseSection = Section.S07248;
        }

     
        
        public override Move Play()
        {
            //Console.WriteLine(playCount);
            playCount++;
            /*
            Move bestMove = Move.Rock;
            if (!prev.HasValue)
            {
                return Move.Rock;          
            }
            switch (bestMove)
            {
                case Move.Rock;
                case Move.Scissors;
                    return Move.Spock;
                case Move.Paper;
                case Move.Lizard;
                    return Move.Scissors;
                case Move.Spock;
                    return Move.Lizard;
                    default;
                    return Move.Lizard;

               
            }
            */

            if (upgradeAI == false)
            {
                //Console.WriteLine(playCount);
                //if(rockCount > paperCount ? rockCount : (rockCount > paperCount) ? rockCount : (paperCount > scissorsCount) ? rockCount : (rockCount > spockCount) ? rockCount : (rockCount > lizardCount) ? true : false)
               // {
              //      newCount = rockCount;
               // }
              //  total = (rockMax + paperMax + scissorMax + spockMax + lizardMax) / 2;

                //Console.WriteLine(newCount);
                
                if (circle == false)
                {
                    Observe(enemy);//Get enemy, play normal AI
                }

                if (normal == false)//Will stop when normal Ai is true,
                {
                    CircleCheck(enemy);//Check if circular AI, will overwrite previous enemy. After 5 battles it will determine it's a normal AI or not.
                }
                if (circle == false)//When it's not circular Ai, will check for spam.Wont play anything unless 5 in a row.
                {
                    SpamCheck(enemy);
                }
                EnemyCounter(enemy);
                return playMove;
            }

            if (upgradeAI == true)//My normal Ai but different move rates.
            {
                // Console.WriteLine("Upgrade ai being called......");

                //Console.WriteLine("CURRENT ENEMY ROLLS " +);
                upgradeCount++;

                if (rockMax > paperMax && rockMax > scissorMax && rockMax > spockMax && rockMax > lizardMax && !upgradeRoll)
                {
                    //Console.WriteLine("MOST ROCKS");
                    //scissorMax = 1;
                    //lizardMax = 1;
                    rockMax *= 10; //rockMax + 100;//Plays paper
                   // spockMax *= 5;//Plays Scissors
                    upgradeRoll = true;
                    total = (rockMax + paperMax + scissorMax + spockMax + lizardMax);
                    //Console.WriteLine("MAX ROCKS : " + rockMax + "MAX PAPER : " + (rockMax + paperMax) + "MAX SCISSORS : " + (rockMax + paperMax + scissorMax) + "MAX SPOCK : " + (rockMax + paperMax + scissorMax + spockMax) + "MAX LIZARD : " + (rockMax + paperMax + scissorMax + spockMax + lizardMax) + "  TOTAL " + total);


                }
                else if (paperMax > rockMax && paperMax > scissorMax && paperMax > spockMax && paperMax > lizardMax && !upgradeRoll)
                {
                    //Console.WriteLine("MOST PAPERS");
                    //rockMax = 1;
                    //spockMax = 1;
                    paperMax *= 10;// paperMax + 100;//Plays scissors
                   // lizardMax *= 5;
                    upgradeRoll = true;
                    total = (rockMax + paperMax + scissorMax + spockMax + lizardMax);
                    //Console.WriteLine("MAX ROCKS : " + rockMax + "MAX PAPER : " + (rockMax + paperMax) + "MAX SCISSORS : " + (rockMax + paperMax + scissorMax) + "MAX SPOCK : " + (rockMax + paperMax + scissorMax + spockMax) + "MAX LIZARD : " + (rockMax + paperMax + scissorMax + spockMax + lizardMax) + "  TOTAL " + total);


                }
                else if (scissorMax > rockMax && scissorMax > paperMax && scissorMax > spockMax && scissorMax > lizardMax && !upgradeRoll)
                {
                    //Console.WriteLine("MOST SCISSORS");
                    scissorMax *= 10;// scissorMax + 100;//Plays Spock
                   // rockMax *= 5;
                   // paperMax = 1;
                    //lizardMax = 1;
                    upgradeRoll = true;
                    total = (rockMax + paperMax + scissorMax + spockMax + lizardMax);
                    //Console.WriteLine("MAX ROCKS : " + rockMax + "MAX PAPER : " + (rockMax + paperMax) + "MAX SCISSORS : " + (rockMax + paperMax + scissorMax) + "MAX SPOCK : " + (rockMax + paperMax + scissorMax + spockMax) + "MAX LIZARD : " + (rockMax + paperMax + scissorMax + spockMax + lizardMax) + "  TOTAL " + total);


                }
                else if (spockMax > rockMax && spockMax > paperMax && spockMax > scissorMax && spockMax > lizardMax && !upgradeRoll)
                {
                    //Console.WriteLine("MOST SPOCKS");
                    spockMax *= 10;// spockMax + 100;//Plays Lizard
                   // paperMax *= 5;
                   // scissorMax = 1;
                    //rockMax = 1;
                    upgradeRoll = true;
                    total = (rockMax + paperMax + scissorMax + spockMax + lizardMax);
                    //Console.WriteLine("MAX ROCKS : " + rockMax + "MAX PAPER : " + (rockMax + paperMax) + "MAX SCISSORS : " + (rockMax + paperMax + scissorMax) + "MAX SPOCK : " + (rockMax + paperMax + scissorMax + spockMax) + "MAX LIZARD : " + (rockMax + paperMax + scissorMax + spockMax + lizardMax) + "  TOTAL " + total);


                }
                else if (lizardMax > rockMax && lizardMax > paperMax && lizardMax > scissorMax && lizardMax > spockMax && !upgradeRoll)
                {

                    //Console.WriteLine("MOST LIZARDS");
                    lizardMax *= 10;// lizardMax + 100;//Plays Rock
                    //scissorMax *= 5;
                   // spockMax = 1;
                   // paperMax = 1;
                    upgradeRoll = true;
                    total = (rockMax + paperMax + scissorMax + spockMax + lizardMax);
                    //Console.WriteLine("MAX ROCKS : " + rockMax + "MAX PAPER : " + (rockMax + paperMax) + "MAX SCISSORS : " + (rockMax + paperMax + scissorMax) + "MAX SPOCK : " + (rockMax + paperMax + scissorMax + spockMax) + "MAX LIZARD : " + (rockMax + paperMax + scissorMax + spockMax + lizardMax) + "  TOTAL " + total);


                }



                //Console.WriteLine("We're at upgraded AI " + upgradeCount);
                // Console.WriteLine("The number of playcount reached. " + playCount);

                //Rock Higher than paper, if so, is Rock higher then scissors?,        if so, rock higher then spock?        if so is rock higher than lizard? then rock, else.... liz
                //int v = rockCount > paperCount ? (rockCount > scissorsCount ? (rockCount > spockCount ? ((rockCount > lizardCount ? rockCount : lizardCount) : spockCount//(rockCount > lizardCount ? rockCount : lizardCount) : scissorsCount) : paperCount;

                

                

               
                int roll = ran.Next((total + 1));

               // Console.WriteLine("\n\nNUMBER ROLLED" + roll);

                if (roll >= 0 && roll <= (rockMax))
                {
                   // Console.WriteLine("Beating ROCK");
                    playMove = Move.Paper;
                  //  Console.WriteLine("Playing " + playMove);
                    return playMove;
                }
                else if (roll > (rockMax) && roll <= (rockMax + paperMax))
                {
                   // Console.WriteLine("Beating PAPER");
                    playMove = Move.Scissors;
                  //  Console.WriteLine("Playing " + playMove);
                    return playMove;
                }
                else if (roll > (rockMax + paperMax) && roll <= (rockMax + paperMax + scissorMax))
                {
                   // Console.WriteLine("Beating SCISSORS");
                    playMove = Move.Spock;
                  //  Console.WriteLine("Playing " + playMove);
                    return playMove;
                }
                else if (roll > (rockMax + paperMax + scissorMax) && roll <= (rockMax + paperMax + scissorMax + spockMax))
                {
                  // Console.WriteLine("Beating SPOCK");
                    playMove = Move.Lizard;
                   // Console.WriteLine("Playing " + playMove);
                    return playMove;
                }
                else if (roll > (rockMax + paperMax + scissorMax + spockMax) && roll <= (rockMax + paperMax + scissorMax + spockMax + lizardMax))
                {
                   // Console.WriteLine("Beating LIZARD");
                    playMove = Move.Rock;
                   // Console.WriteLine("Playing " + playMove);
                    return playMove;
                }
                else
                {
                    Console.WriteLine("Random MOve sent");
                    return RandomMove();
                    
                }
                //Console.WriteLine("Number rolled : " + roll);

                //if (upgradeCount == 66)
                //{
                //    upgradeAI = false;
               //     upgradeCount = 0;
              //  }

            }

            //Console.WriteLine("MOVE IM ABOUT TO PLAY IS OUT OF LOOP " + playMove);      

            return playMove;//RandomMove();



            //Check if it's between 0 and 5. if true, then you add it inside the list.
        }

        private void CircleCheck(Move enemy)
        {
            // Stack<Move> myS = new Stack<Move>();

            // myS.Push(enemy);           
            // myS.Peek();

            if (check == true && !upgradeAI)//Checking the circle.
            {
                if (enemy == Move.Scissors && lastEnemyMove == Move.Spock)
                {
                    //  Console.WriteLine("Calling SPOCK in CIRCULAR AI");

                    playMove = enemy;
                    //  Console.WriteLine("MY MOVE IS " + playMove);
                    circleCount++;
                }
                else if (enemy == Move.Paper && lastEnemyMove == Move.Scissors)
                {
                    //  Console.WriteLine("Calling scissors in CIRCULAR AI");
                    playMove = enemy;

                    //  Console.WriteLine("MY MOVE IS " + playMove);
                    circleCount++;
                }
                else if (enemy == Move.Rock && lastEnemyMove == Move.Paper)
                {

                    //Console.WriteLine("Calling PAPER in CIRCULAR AI");
                    playMove = enemy;

                    // Console.WriteLine("MY MOVE IS " + playMove);
                    circleCount++;
                }
                else if (enemy == Move.Lizard && lastEnemyMove == Move.Rock)
                {
                    //Console.WriteLine("Calling ROCK in CIRCULAR AI");
                    playMove = enemy;
                    //playMove = Move.Rock;
                    //Console.WriteLine("MY MOVE IS " + playMove);
                    circleCount++;
                }
                else if (enemy == Move.Spock && lastEnemyMove == Move.Lizard)
                {
                    //Console.WriteLine("Calling LIZARD in CIRCULAR AI");
                    playMove = enemy;
                    //playMove = Move.Lizard;
                    //Console.WriteLine("MY MOVE IS " + playMove);
                    circleCount++;
                }
                else
                {
                    // Console.WriteLine("Circle has been reset or not found.");
                    circleCount = 0;
                    normalCount--;
                    circle = false;
                    if (normalCount <= -5)
                    {
                        // Console.WriteLine("AI HAS BEEN CONFIRMED NORMAL");
                        normal = true;
                    }
                    playMove = lastEnemyMove;
                }
            }

            lastEnemyMove = enemy;//Store the last enemy move.

            if (check == false)//Play this when initialised.
            {
                playMove = Move.Spock;
            }

            check = true;//Checking for circular shall commence next battle.

            if (circleCount >= 5 && circle == false)//Will say if circle Ai has been found.
            {

                // Console.WriteLine("CIRCLE DETECTED");
                circle = true;
            }
        }

        private void SpamCheck(Move enemy)
        {
            if (!upgradeAI)
            {
                if (enemy == Move.Rock)//Checking variable value.
                {
                    // rockCount++;
                    constRock += 1;
                    constPaper = 0;
                    constScissors = 0;
                    constLizard = 0;
                    constSpock = 0;
                }
                else if (enemy == Move.Paper)
                {
                    //paperCount++;
                    constPaper += 1;

                    constRock = 0;
                    constScissors = 0;
                    constLizard = 0;
                    constSpock = 0;
                }
                else if (enemy == Move.Scissors)
                {
                    //scissorsCount++;
                    constScissors += 1;

                    constRock = 0;
                    constPaper = 0;
                    constLizard = 0;
                    constSpock = 0;
                }
                else if (enemy == Move.Spock)
                {
                    //spockCount++;
                    constSpock += 1;

                    constRock = 0;
                    constPaper = 0;
                    constScissors = 0;
                    constLizard = 0;
                }
                else if (enemy == Move.Lizard)
                {
                    //lizardCount++;
                    constLizard += 1;

                    constRock = 0;
                    constPaper = 0;
                    constScissors = 0;
                    constSpock = 0;
                }
                else
                {
                    //Console.WriteLine("Weird move detected, Played random AI (TACS)");
                    playMove = RandomMove();
                }


                //Check if spams only one move.

                if (constRock >= 7)//Checking variable value. When above 5 it should play this move.
                {
                    //Console.WriteLine("SPAMMER DETECTED");
                    playMove = Move.Paper;
                    spam = true;
                }
                if (constPaper >= 7)//Checking variable value. When above 5 it should play this move.
                {
                    //Console.WriteLine("SPAMMER DETECTED");
                    playMove = Move.Scissors;
                    spam = true;
                }
                if (constScissors >= 7)//Checking variable value. When above 5 it should play this move.
                {
                    // Console.WriteLine("SPAMMER DETECTED");
                    playMove = Move.Spock;
                    spam = true;
                }
                if (constSpock >= 7)//Checking variable value. When above 5 it should play this move.
                {
                    //Console.WriteLine("SPAMMER DETECTED");
                    playMove = Move.Lizard;
                    spam = true;
                }
                if (constLizard >= 7)//Checking variable value. When above 5 it should play this move.
                {
                    // Console.WriteLine("SPAMMER DETECTED");
                    playMove = Move.Scissors;
                    spam = true;
                }
                if (constRock < 7 && constPaper < 7 && constScissors < 7 && constSpock < 7 && constLizard < 7)
                {
                    spam = false;
                }
            }
        }

        public override void Observe(Move E)
        {
            // Console.WriteLine("Current moves played, Rock :" + rockCount + " Paper :" + paperCount + " Scissors :" + scissorsCount + " Spock :" + spockCount + " Lizard :" + lizardCount);
            //Console.WriteLine("TOTAL MOVES PLAYED " + (rockCount + paperCount + scissorsCount + spockCount + lizardCount));

            //base.Observe(E);//Inspect the target
            enemy = E;//Analyze the enemy, Store in this variable.

            //if (prev.HasValue)
           // {
           //     data[(int)prev, (int)enemy]++;
          //  }

            if (circle == false && spam == false && upgradeAI == false)
            {
               
                if (playCount == 30)//27 gives wins sometimes//33 alot of wins //30 SEEMS like the perfect balance
                {
                    rockMax = rockCount;//(rockCount / 2);
                    paperMax = paperCount;//(paperCount / 2);
                    scissorMax = scissorsCount;//(scissorsCount / 2);
                    lizardMax = lizardCount; //(lizardCount / 2);
                    spockMax = spockCount; //(spockCount / 2);
                    upgradeAI = true;

                    //Console.WriteLine("UPGRADING AI WE HAVE REACHED PLAYCOUNT 25");

                   // playCount = 0;

                    playMove = RandomMove();

                }
            }

            
            //When nothing's above 5, then we will play this.//ONLY WHEN AI HAS PLAYED 100 ROUNDS!
            
            //total = (rockMax + paperMax + scissorMax + spockMax + lizardMax);

            //Console.WriteLine(newCount);

        }

        public Move EnemyCounter(Move jerk)
        {
            if (jerk == Move.Rock)
            {
                ++rockCount;
               // Console.WriteLine("INCREASING ROCK" + rockCount);
            }
            else if (jerk == Move.Paper)
            {
                ++paperCount;
               // Console.WriteLine("INCREASING PAPER" + paperCount);
            }
            else if (jerk == Move.Scissors)
            {
                ++scissorsCount;
               // Console.WriteLine("INCREASING SCISSORS" + scissorsCount);
            }
            else if (jerk == Move.Spock)
            {
                ++spockCount;
               // Console.WriteLine("INCREASING spock" + spockCount);
            }
            else if (jerk == Move.Lizard)
            {
                ++lizardCount;
               // Console.WriteLine("INCREASING lizard" + lizardCount);
            }


            return jerk;
        }
    }


}
