using EightPuzzleSolver.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EightPuzzleSolver.EightPuzzle
{
    public class RowColumnHeuristicFunction : IHeuristicFunction<EightPuzzleState>
    {
        private readonly Dictionary<int, int> _tileExpectedRow = new Dictionary<int, int>();
        private readonly Dictionary<int, int> _tileExpectedColumn = new Dictionary<int, int>();

        public RowColumnHeuristicFunction (Board goalBoard)
        {
            string a = goalBoard.ToString();

            int[] b = new int[9];
            string[] numbers = Regex.Split(a, @"\D+");
            for (int i = 0; i < 9; i++)
            {
                b[i] = int.Parse(numbers[i + 2]);
            }

            for (int i = 0; i < 9; i++)
            {
                if (i < 3)
                {
                    _tileExpectedRow.Add(b[i], 0);
                    _tileExpectedColumn.Add(b[i], i);
                }
                else if (i < 6)
                {
                    _tileExpectedRow.Add(b[i], 1);
                    _tileExpectedColumn.Add(b[i], i - 3);
                }
                else
                {
                    _tileExpectedRow.Add(b[i], 2);
                    _tileExpectedColumn.Add(b[i], b[i] - 6);
                }
            }

        }

        public double Calculate(EightPuzzleState state)
        {
            string a = state.Board.ToString();
            int count = 0;
            int[] b = new int[9];
            string[] numbers = Regex.Split(a, @"\D+");
            for (int i = 0; i < 9; i++)
            {
                b[i] = int.Parse(numbers[i + 2]);
            }

            for(int j=0; j<b.Length; j++)
            {
                if(j != _tileExpectedRow[b[j]])
                {
                    count++;
                }
                
                if(j != _tileExpectedColumn[b[j]])
                {
                    count++;
                }
            }

            return count;
        }
    }
}
