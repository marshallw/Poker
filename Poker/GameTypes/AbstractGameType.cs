using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Poker.Models;

namespace Poker.GameTypes
{
    public abstract class AbstractGameType
    {
        protected List<Hand> _hands;
        protected int _maxHandSize = 5;

        public int MaxHandSize => _maxHandSize;

        public void AddHand(params Hand[] hands)
        {
            foreach (var hand in hands)
            {
                if (hand.cards.Count != _maxHandSize)
                {
                    throw new HandWrongSizeException($"Hand is wrong size.  Expected: {_maxHandSize}.  Actual: {hand.cards.Count}");
                }

                _hands.Add(hand);
            }
        }

        public abstract HandDetails FindWinningHand();
    }
}
