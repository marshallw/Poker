using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Poker.Models;
using Poker.HandEvaluators;

namespace Poker.GameTypes
{
    public abstract class AbstractGameType
    {
        protected List<Hand> hands;
        protected int maxHandSize;
        protected HandRanker<IPokerHandEvaluator> handEvaluator;

        public int MaxHandSize => maxHandSize;

        public AbstractGameType(int maxHand)
        {
            maxHandSize = maxHand;
            hands = new List<Hand>();
        }

        public void AddHand(params Hand[] hands)
        {
            foreach (var hand in hands)
            {
                if (hand.Cards.Count != maxHandSize)
                {
                    throw new HandWrongSizeException($"Hand is too large.  Max: {maxHandSize}.  Actual: {hand.Cards.Count}");
                }

                this.hands.Add(hand);
            }
        }

        public abstract HandDetails FindWinningHand();
    }
}
