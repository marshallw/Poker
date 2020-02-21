using Poker.HandEvaluators;
using Poker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Poker.Exceptions;

namespace Poker.GameTypes
{
    public class TexasHoldem : AbstractGameType
    {
        private Hand communityCards;
        private int communityCardsSizeMax;
        public Hand CommunityCards { get; }

        public TexasHoldem(): base(2)
        {
            communityCardsSizeMax = 5;
            handEvaluator = new HandRanker<IPokerHandEvaluator>();
            communityCards = new Hand();
        }

        public override HandDetails FindWinningHand()
        {
            return hands.Select(_ => handEvaluator
                        .RankHand(_, communityCards))
                        .OrderByDescending(_ => _)
                        .First();
        }

        public void AddCardToCommunityHand(params Card[] cards)
        {
            foreach (var card in cards)
            {
                communityCards.AddCard(card);
            }

            if (communityCards.Cards.Count() > communityCardsSizeMax)
                throw new HandWrongSizeException("Community cards has too many cards in it");
        }
    }
}
