using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OefentoetsAds
{
    class GameTreeNode
    {
        private int _marbles;

        private bool _playerATurn;

        GameTreeNode? _leftChild, _rightChild;

        public GameTreeNode(int marbles, bool playerATurn)
        {
            _marbles = marbles;
            _playerATurn = playerATurn;

            if (marbles > 0)
            {
                // maak kinderen
                _leftChild = new GameTreeNode(marbles - 3, !playerATurn);
                _rightChild = new GameTreeNode(marbles - 1, !playerATurn);
            }
        }

        public int countWins(bool playerA)
        {
            // stop criterium
            // if (_leftChild == null && _rightChild == null) {
            if (_marbles <= 0)
            {
                return _playerATurn == playerA ? 1 : 0;
            }

            // recursieve calls
            return _leftChild!.countWins(playerA) + _rightChild!.countWins(playerA);
        }
    }
}
