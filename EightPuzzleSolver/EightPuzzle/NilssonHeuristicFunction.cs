using EightPuzzleSolver.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EightPuzzleSolver.EightPuzzle
{
    public class NilssonHeuristicFunction : IHeuristicFunction<EightPuzzleState>
    {
        private ManhattanHeuristicFunction manhattanHeuristicValue;
        private readonly Dictionary<int, int> _clockwiseTileExpectedPosDict = new Dictionary<int, int>();


        public NilssonHeuristicFunction(Board goalBoard)
        {
            string a = goalBoard.ToString();

            int[] b = new int[9];
            string[] numbers = Regex.Split(a, @"\D+");
            for (int i = 0; i < 9; i++)
            {
                b[i] = int.Parse(numbers[i + 2]);
            }
            this.manhattanHeuristicValue = new ManhattanHeuristicFunction(goalBoard);
            
            for (int i = 0; i < 9; i++)
            {
                if ( i == 2 || i == 5)
                    _clockwiseTileExpectedPosDict.Add(b[i], b[i + 3]);
                else if ( i == 8 || i==7)
                    _clockwiseTileExpectedPosDict.Add(b[i], b[i - 1]);
                else if ( i == 6 || i == 3)
                    _clockwiseTileExpectedPosDict.Add(b[i], b[i - 3]);
                else
                    _clockwiseTileExpectedPosDict.Add(b[i], b[i + 1]);
            }

        }



        public double Calculate(EightPuzzleState state)
        {
            int count = 0;
            string a = state.Board.ToString();
            
            int[] bo = new int[9];
            string[] numbers = Regex.Split(a, @"\D+");
            for(int i=0; i<9; i++)
            {
                bo[i] = int.Parse(numbers[i + 2]);
            }

            
            double manhattanHeuristicValue = this.manhattanHeuristicValue.Calculate(state);
            for (int i = 0; i < bo.Length; i++)
                {
                if (bo[i] != 0)
                {
                    if (i == 2 || i == 5)
                    {
                        if (bo[i + 3] != _clockwiseTileExpectedPosDict[bo[i]])
                            count += 2;
                    }
                    else if (i == 8 || i == 7)
                    {
                        if (bo[i - 1] != _clockwiseTileExpectedPosDict[bo[i]])
                            count += 2;
                    }

                    else if (i == 6 || i == 3)
                    {
                        if (bo[i - 3] != _clockwiseTileExpectedPosDict[bo[i]])
                            count += 2;
                    }
                    else
                    {
                        if (bo[i + 1] != _clockwiseTileExpectedPosDict[bo[i]])
                            count += 1;
                    }
                }

                    
                }
            return count * 3 + manhattanHeuristicValue;
        }
    }
}
