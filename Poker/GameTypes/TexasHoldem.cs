using Poker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Poker.GameTypes
{
    public class TexasHoldem : AbstractGameType
    {
        private Hand communityCards;
        public Hand CommunityCards { get; }

        public override HandDetails FindWinningHand()
        {
            return hands.Select(_ => handEvaluator.RankHand(_, communityCards)).OrderByDescending(_ => _).First();
        }

        public void AddCardToCommunityHand(params Card[] cards)
        {
            foreach (var card in cards)
            {
                communityCards.AddCard(card);
            }
        }
    }
}
