using System;
using System.Collections.Generic;
using System.Linq;

namespace RPSLS
{

	class TRIM : StudentAI
	{
		Dictionary<Move, int> moveCounter = new Dictionary<Move, int>();
		Dictionary<Move, int> finalPatternCounter = new Dictionary<Move, int>();
		int currentMove = 0;
		int breakPoint = 40;
		Move[] favoritePair = new Move[2];
		int minPatternSize = 20;
		int maxPatternSize = 39;
		List<Move> patterns = new List<Move>();
		List<Move> patternsToMatch = new List<Move>();
		List<Move> finalPatternList;
		int finalPatternSize;
		bool isRepeater = true;
		int currentNotMatch = -1;
		Move lastOpponentMove;
		List<bool> repeaterValidator = new List<bool>();

		public TRIM()
		{
            IsDisqualified = true; //Crash in GetMax()
			this.Nickname = "@minhat";
			this.CourseSection = Section.S07248;
		}
        
		public override void Observe(Move opponentMove)
        {

            TrackMove(opponentMove, moveCounter);
			BuildPattern(opponentMove);
			lastOpponentMove = opponentMove;
        }

		public override Move Play()
        {
			currentMove++;
            
            if (currentMove < breakPoint) {
                return RandomMove();
            }

			if (currentMove == breakPoint) {
				FindPattern();
				PrintMoves();
			}

			if (currentMove > breakPoint && currentMove <= 45) {
				FindPattern();
				FindOpponentType();
			}

			return GetAppropriateMove();
            
        }
        
		void FindOpponentType() {
			Move lastCorrectRepeaterMove = GetRepeaterMove(currentMove - 1);
			bool isRepeaterLastMove;

			if (lastCorrectRepeaterMove == lastOpponentMove) {
				isRepeaterLastMove = true;
			}
			else {
				isRepeaterLastMove = false;
			}

			repeaterValidator.Add(isRepeaterLastMove);

			foreach (bool value in repeaterValidator) {
				if (!value) {
					isRepeater = false;
				}
			}

			//Console.WriteLine("============================");
			//Console.WriteLine("last move number: " + (currentMove - 1));
			//Console.WriteLine("lastCorrectRepeaterMove: " + lastCorrectRepeaterMove);
			//Console.WriteLine("last opponent move: " + lastOpponentMove);
			//Console.WriteLine("FindOpponentType ----- IS REPEATER: " + isRepeater);
			//Console.WriteLine("============================");
			//Console.WriteLine();
            
		}

		Move GetAppropriateMove() {
			if (isRepeater) {
				return GetNextMoveSingle(GetRepeaterMove(currentMove));
			}
    		GetFavoritePair();
    		return GetNextMovePair();
		}

		void TrackMove(Move opponentMove, Dictionary<Move,int> tracker) {
			if (tracker.ContainsKey(opponentMove)) {
				tracker[opponentMove]++;
			} else {
				tracker.Add(opponentMove, 1);
			}
		}

		Move GetFavoriteMove(int value) {
			return moveCounter.FirstOrDefault(x => x.Value == value).Key;
		}

		int GetMax(int order) {
			return moveCounter.Values.OrderByDescending(x => x).Distinct().Skip(order).First();
		}
        
		void GetFavoritePair() {
			for (var i = 0; i < 2; i++) {
				favoritePair[i] = GetFavoriteMove(GetMax(i));
			}
		}
       
        
        /*
         * Rock & Spock => Paper 
         * Paper & Lizard => Scissors 
         * Scissors & Rock => Spock 
         * Spock & Paper => Lizard
         * Lizard & Scissors => Rock
         */
		Move GetNextMovePair() {
			var favoritePairSet = new HashSet<Move>(favoritePair);
			if (favoritePairSet.Contains(Move.Rock) && favoritePairSet.Contains(Move.Spock)) {
				return Move.Paper;
			} else if (favoritePairSet.Contains(Move.Paper) && favoritePairSet.Contains(Move.Lizard)) {
				return Move.Scissors;
			} else if (favoritePairSet.Contains(Move.Scissors) && favoritePairSet.Contains(Move.Rock)) {
				return Move.Spock;
			} else if (favoritePairSet.Contains(Move.Spock) && favoritePairSet.Contains(Move.Paper)) {
				return Move.Lizard;
			} else if (favoritePairSet.Contains(Move.Lizard) && favoritePairSet.Contains(Move.Scissors)) {
				return Move.Rock;
			} else {
				return GetNextMoveSingle(favoritePair[0]);
			}
		}

		Move GetNextMoveSingle(Move favMove) {
			switch (favMove)
            {
                case (Move.Rock):
                case (Move.Spock):
                    return Move.Paper;
                case (Move.Lizard):
                case (Move.Paper):
                    return Move.Scissors;
                case (Move.Scissors):
                    return Move.Rock;
                default:
                    return RandomMove();
            }
		}

		void BuildPattern(Move opponentMove) {
			int lastMove = currentMove - 1;
			if (lastMove < minPatternSize) {
				patterns.Add(opponentMove);
			} else if (lastMove >= minPatternSize && lastMove < maxPatternSize) {
				patternsToMatch.Add(opponentMove);
			}
		}

		void FindPattern() {
			var currentPatternsIndex = 0;
			var i = 0;
			while (i < patternsToMatch.Count) {
				if (patternsToMatch[i] != patterns.ElementAt(currentPatternsIndex) && patternsToMatch[i] != patterns.ElementAt(0)) {
					currentPatternsIndex = 0;
					currentNotMatch = i;
					i++;
				} else if (patternsToMatch[i] != patterns.ElementAt(currentPatternsIndex) && patternsToMatch[i] == patterns.ElementAt(0)) {
                    currentPatternsIndex = 0;
                    currentNotMatch = i - 1;
                    currentPatternsIndex++;
                    i++;
                }
				else if (patternsToMatch[i] == patterns.ElementAt(currentPatternsIndex)) {
					currentPatternsIndex++;
					i++;
				} 
			}

			var numberOfNotMatches = currentNotMatch + 1;
			var rest = patternsToMatch.Skip(0).Take(numberOfNotMatches);
			var finalPattern = patterns.Concat(rest);

			finalPatternList = finalPattern.ToList();
			finalPatternSize = finalPatternList.Count;
		}
        
		Move GetRepeaterMove(int moveNumber) {
			int repeaterMoveIndex = GetRepeaterMoveIndex(moveNumber);
			return finalPatternList.ElementAt(repeaterMoveIndex);
		}

        /*
         * Get repeater move at a specific index in final pattern list
         */
		int GetRepeaterMoveIndex(int moveNumber) {
			int repeaterMoveNumber = moveNumber % finalPatternSize;

			if (repeaterMoveNumber > 0) {
				return repeaterMoveNumber - 1;
            }
            else {
				return finalPatternSize - 1;
            }
		}

		void PrintMoves()
        {
            return;
            Console.WriteLine();
            Console.WriteLine("=========GENERAL===========");
            Console.WriteLine("CURRENT MOVE NUMBER: " + currentMove);
			Console.WriteLine("LAST OPPONENT MOVE: " + lastOpponentMove);
            Console.WriteLine("CURRENT NOT MATCH INDEX: " + currentNotMatch);
            Console.WriteLine("IS REPEATER: " + isRepeater);
            Console.WriteLine("=============================");
            Console.WriteLine();

            Console.WriteLine("=========PATTERNS===========");
            int i = 0;
            foreach (var move in patterns)
            {
                Console.WriteLine(i + ". " + move);
                i++;
            }
            Console.WriteLine("PATTERNS COUNT---------------" + patterns.Count);
            Console.WriteLine("=============================");
            Console.WriteLine();

            Console.WriteLine("========PATTERNS TO MATCH============");
            int j = 0;
            foreach (var move in patternsToMatch)
            {
                Console.WriteLine(j + ". " + move);
                j++;
            }
            Console.WriteLine("PATTERNS TO MATCH COUNT------------" + patternsToMatch.Count);
            Console.WriteLine("=====================================");

            Console.WriteLine();

            Console.WriteLine("========FINAL PATTERN=======");
			int k = 0;
            foreach (var m in finalPatternList)
            {
				Console.WriteLine(k + " - " + m);
				k++;
            }
            Console.WriteLine("FINAL PATTERN COUNT----------" + finalPatternSize);
            Console.WriteLine("============================");
            Console.WriteLine();
        }
	}
}