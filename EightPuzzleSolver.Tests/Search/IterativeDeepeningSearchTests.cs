﻿using System.Collections.Generic;
using System.Linq;
using EightPuzzleSolver.Search;
using EightPuzzleSolver.Search.Algorithms;
using Xunit;

namespace EightPuzzleSolver.Tests.Search
{
    public class IterativeDeepeningSearchTests
    {
        private readonly Dictionary<string, DummyProblemState> _states = new Dictionary<string, DummyProblemState>();

        private readonly DummyProblemState _goalState;

        public IterativeDeepeningSearchTests()
        {
            foreach (var name in new[] { "A", "B", "C", "D", "E", "F" })
            {
                _states[name] = new DummyProblemState(0, name);
            }
            _goalState = DummyProblemState.CreateGoalState();
            _states[_goalState.Name] = _goalState;
        }

        [Fact]
        public void ShouldFindGoal()
        {
            _states["A"].NextStatesList = new[] { _states["B"], _states["C"] };
            _states["B"].NextStatesList = new[] { _states["D"] };
            _states["C"].NextStatesList = new[] { _states["E"] };
            _states["E"].NextStatesList = new[] { _states["F"] };
            _states["F"].NextStatesList = new[] { _goalState };

            var problem = new DummyProblem(_states["A"]);

            var search = new IterativeDeepeningSearch<DummyProblemState>();

            var result = search.Search(problem).ToList();

            Assert.Equal(new[] { _states["A"], _states["C"], _states["E"], _states["F"], _goalState }, result);
        }

        [Fact]
        public void ShouldFail()
        {
            _states["A"].NextStatesList = new[] { _states["B"], _states["C"] };
            _states["B"].NextStatesList = new[] { _states["D"] };
            _states["C"].NextStatesList = new[] { _states["E"] };
            _states["E"].NextStatesList = new[] { _states["F"] };

            var problem = new DummyProblem(_states["A"]);

            var search = new IterativeDeepeningSearch<DummyProblemState>();

            var result = search.Search(problem).ToList();

            Assert.Empty(result);
        }
    }
}
