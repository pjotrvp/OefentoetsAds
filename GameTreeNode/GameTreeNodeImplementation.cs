using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTreeNode
{
    internal class GameTreeNodeImplementation
    {
        private readonly int _marbles;

        private readonly bool _playerATurn;

        private readonly GameTreeNodeImplementation? _leftChild, _rightChild;

        public GameTreeNodeImplementation(int marbles, bool playerATurn)
        {
            _marbles = marbles;
            _playerATurn = playerATurn;

            if (marbles > 0)
            {
                _leftChild = new GameTreeNodeImplementation(marbles - 3, !playerATurn);
                _rightChild = new GameTreeNodeImplementation(marbles - 1, !playerATurn);
            }
        }

        public int CountWins(bool playerA)
        {
            if (_marbles <= 0)
            {
                return _playerATurn == playerA ? 1 : 0;
            }

            return _leftChild!.CountWins(playerA) + _rightChild!.CountWins(playerA);
        }
    }
}
