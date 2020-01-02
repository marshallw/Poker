using System;
using System.Collections.Generic;
using System.Text;
using Poker.Models;
using System.Linq;
using Poker.HandEvaluators;

namespace Poker.GameTypes
{
    public class PokerGame: AbstractGameType
    {
        private HandRanker<IPokerHandEvaluator> handEvaluator;

        public PokerGame()
        {
            hands = new List<Hand>();
            handEvaluator = new HandRanker<IPokerHandEvaluator>();
        }

        public override HandDetails FindWinningHand()
        {
            return hands.Select(_ => handEvaluator.RankHand(_)).OrderByDescending(_ => _).First();
        }
    }
}
