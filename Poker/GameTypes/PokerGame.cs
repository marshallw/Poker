using System;
using System.Collections.Generic;
using System.Text;
using Poker.Models;
using System.Linq;

namespace Poker.GameTypes
{
    public class PokerGame: AbstractGameType
    {
        private List<Hand> _hands;

        public PokerGame()
        {
            _hands = new List<Hand>();
        }

        public Hand FindWinningHand()
        {
            IHand highest;
            foreach (var hand in _hands)
            {
                IHand evaluator = HandRanker.RankHand(hand);
                if (evaluator > highest)
                {
                    highest = evaluator;
                }
            }

            return highest;
        }
    }
}
