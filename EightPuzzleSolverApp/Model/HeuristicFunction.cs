using System.ComponentModel;

namespace EightPuzzleSolverApp.Model
{
    public enum HeuristicFunction
    {
        [Description("Without heuristic (h(x) = 0)")]
        NoHeuristic,
        [Description("Manhattan Distance")]
        ManhattanDistance,
        [Description("Nilsson Heuristic")]
        NilssonHeuristic,
        [Description("Row Column Heuristic")]
        RowColumnHeuristic
        
    }
}
