using System;
using System.Collections.Generic;
using System.Text;
using Poker.Models;
using System.Linq;
using Poker.HandEvaluators;
using Poker.PokerHands;

namespace Poker.GameTypes
{
    public class PokerGame: AbstractGameType
    {
        private HandRanker<IPokerHandEvaluator> _handEvaluator;
        public PokerGame()
        {
            _hands = new List<Hand>();
            _handEvaluator = new HandRanker<IPokerHandEvaluator>();
        }

        public override HandDetails FindWinningHand()
        {
            HandDetails highest = new HandDetails();
            foreach (var hand in _hands)
            {
                HandDetails evaluator = _handEvaluator.RankHand(hand);
                if (evaluator > highest)
                {
                    highest = evaluator;
                }
            }

            return highest;
        }
    }
}
