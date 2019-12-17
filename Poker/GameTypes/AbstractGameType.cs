using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Poker.Models;

namespace Poker.GameTypes
{
    public abstract class AbstractGameType
    {
        private List<Hand> _hands;
        private int _maxHandSize = 5;

        public int MaxHandSize => _maxHandSize;

        public void AddHand(Hand hand)
        {
            if (hand.cards.Count != _maxHandSize)
            {
                throw new HandWrongSizeException($"Hand is wrong size.  Expected: {_maxHandSize}.  Actual: {hand.cards.Count}");
            }

            _hands.Add(hand);
        }

        public abstract Hand FindWinningHand();
    }
}
