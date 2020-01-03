using Poker.HandEvaluators;
using Poker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Poker.GameTypes
{
    public class SevenCardStud : AbstractGameType
    {
        public SevenCardStud(): base(7)
        {
            handEvaluator = new HandRanker<IPokerHandEvaluator>();
        }

        public override HandDetails FindWinningHand()
        {
            return hands.Select(_ => handEvaluator.RankHand(_)).OrderByDescending(_ => _).First();
        }
    }
}
