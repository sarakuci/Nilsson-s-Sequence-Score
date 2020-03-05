using System;
using System.Collections.Generic;
using EightPuzzleSolver.Search;

namespace EightPuzzleSolver.EightPuzzle
{
    public class ManhattanHeuristicFunction : IHeuristicFunction<EightPuzzleState>
    {
        private readonly Dictionary<int, Position> _tileExpectedPosDict = new Dictionary<int, Position>();
        private Board gB;

        public ManhattanHeuristicFunction(Board goalBoard)
        {
            this.gB = goalBoard;
            for (int row = 0; row < goalBoard.RowCount; row++)
            {
                for (int col = 0; col < goalBoard.ColumnCount; col++)
                {
                    int val = goalBoard[row, col];

                    _tileExpectedPosDict[val] = new Position(row, col);
                }
            }
        }



        public double Calculate(EightPuzzleState state)
        {
            int result = 0;

            int expected = 0;

            for (int row = 0; row < state.Board.RowCount; row++)
            {
                for (int col = 0; col < state.Board.ColumnCount; col++)
                {
                    int val = state.Board[row, col];
                    expected = gB[row,col];

                    var expectedPos = _tileExpectedPosDict[val];

                    if (val != 0 && val != expected)
                    {
                        result += Math.Abs(row - expectedPos.Row) +
                            Math.Abs(col - expectedPos.Column);
                    }
                }
            }

            return result;
        }

        private readonly Dictionary<int, int> _clockwiseTileExpectedPosDict = new Dictionary<int, int>();

        public void NilssonsHeuristics(Board goalBoard)
        {
            Position position1;
            Position position2;

            for (int i = 0; i < goalBoard.RowCount; i++)
                for (int j = 0; i < goalBoard.ColumnCount; i++)
                {
                    if (goalBoard[i, j] != 0)
                    {
                        if (i == 0 && j < goalBoard.ColumnCount - 1)
                            _clockwiseTileExpectedPosDict.Add(goalBoard[i, j], goalBoard[i, j + 1]);
                        else if (j == goalBoard.ColumnCount - 1 && i < goalBoard.RowCount - 1)
                            _clockwiseTileExpectedPosDict.Add(goalBoard[i, j], goalBoard[i + 1, j]);
                        else if (i == goalBoard.RowCount - 1 && j > 0)
                            _clockwiseTileExpectedPosDict.Add(goalBoard[i, j], goalBoard[i, j - 1]);
                        else if (i > 0 && j == 0)
                            _clockwiseTileExpectedPosDict.Add(goalBoard[i, j], goalBoard[i - 1, j]);
                        else if (i == 1 && j == 1)
                            _clockwiseTileExpectedPosDict.Add(goalBoard[i, j], goalBoard[i, j + 1]);
                        //position1 = new Position(i, j);
                        //if (i == 0 && j < goalBoard.ColumnCount - 1)
                        //    position2 = new Position(i, j + 1);

                        //else if (j == goalBoard.ColumnCount - 1 && i < goalBoard.RowCount - 1)
                        //    position2 = new Position(i + 1, j);

                        //else if (i == goalBoard.RowCount - 1 && j > 0)
                        //    position2 = new Position(i, j - 1);

                        //else if (i > 0 && j == 0)
                        //    position2 = new Position(i - 1, j);

                        //else if (i == 1 && j == 1)
                        //    position2 = new Position(i, j + 1);

                    }
                }
        }


         //if (state.Board[i, j] != 0)
         //           {
         //               if (i == 0 && j<state.Board.ColumnCount - 1)
         //               {
         //                   if (!(state.Board[i, j + 1] == _clockwiseTileExpectedPosDict[state.Board[i, j]]))
         //                       count += 2;
         //               }
         //               else if (j == state.Board.ColumnCount - 1 && i<state.Board.RowCount - 1)
         //               {
         //                   if (!(state.Board[i + 1, j] == _clockwiseTileExpectedPosDict[state.Board[i, j]]))
         //                       count += 2;
         //               }
         //               else if (i == state.Board.RowCount - 1 && j > 0)
         //               {
         //                   if (!(state.Board[i, j - 1] == _clockwiseTileExpectedPosDict[state.Board[i, j]]))
         //                       count += 2;
         //               }
         //               else if (i > 0 && j == 0)
         //               {
         //                   if (!(state.Board[i - 1, j] == _clockwiseTileExpectedPosDict[state.Board[i, j]]))
         //                       count += 2;
         //               }
         //               else if (i == 1 && j == 1)
         //               {
         //                   if (!(state.Board[i, j + 1] == _clockwiseTileExpectedPosDict[state.Board[i, j]]))
         //                       count++;
         //               }
         //           }
        //public int checkClockwiseTile(EightPuzzleState state)
        //{
        //    int count = 0;
        //    for (int i=0;i<=state.Board.RowCount;i++)
        //        for (int j=0; i<=state.Board.ColumnCount;i++)
        //        {
        //            if (state.Board[i, j] != 0)
        //            {
        //                if (i == 0 && j < state.Board.ColumnCount - 1)
        //                {
        //                    if (!(state.Board[i, j + 1] == _clockwiseTileExpectedPosDict[state.Board[i, j]]))
        //                        count += 2;
        //                }
        //                else if (j == state.Board.ColumnCount - 1 && i < state.Board.RowCount - 1)
        //                {
        //                    if (!(state.Board[i + 1, j] == _clockwiseTileExpectedPosDict[state.Board[i, j]]))
        //                        count += 2;
        //                }
        //                else if (i == state.Board.RowCount - 1 && j > 0)
        //                {
        //                    if (!(state.Board[i, j - 1] == _clockwiseTileExpectedPosDict[state.Board[i, j]]))
        //                        count += 2;
        //                }
        //                else if (i > 0 && j == 0)
        //                {
        //                    if (!(state.Board[i - 1, j] == _clockwiseTileExpectedPosDict[state.Board[i, j]]))
        //                        count += 2;
        //                }
        //                else if (i == 1 && j == 1)
        //                {
        //                    if (!(state.Board[i, j + 1] == _clockwiseTileExpectedPosDict[state.Board[i, j]]))
        //                        count++;
        //                }
        //            }
        //            return count;
        //        }


        //    //if(state.Board[0][0] == 0 && state.Board.Column[0][0] == 0)

        //    return true;
        //}
    }
}
