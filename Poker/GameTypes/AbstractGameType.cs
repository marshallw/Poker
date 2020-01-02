using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Poker.Models;

namespace Poker.GameTypes
{
    public abstract class AbstractGameType
    {
        protected List<Hand> hands;
        protected int maxHandSize = 5;

        public int MaxHandSize => maxHandSize;

        public void AddHand(params Hand[] hands)
        {
            foreach (var hand in hands)
            {
                if (hand.cards.Count != maxHandSize)
                {
                    throw new HandWrongSizeException($"Hand is too large.  Max: {maxHandSize}.  Actual: {hand.cards.Count}");
                }

                this.hands.Add(hand);
            }
        }

        public abstract HandDetails FindWinningHand();
    }
}
