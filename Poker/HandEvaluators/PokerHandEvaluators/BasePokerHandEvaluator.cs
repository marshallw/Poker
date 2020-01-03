using Poker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Poker.HandEvaluators
{
    public abstract class BasePokerHandEvaluator : IPokerHandEvaluator
    {
        public abstract HandDetails GetHandValue(Hand hand);

        public HandDetails GetHandValue(Hand hand, Hand communityCards)
        {
            var cards = hand.Cards.ToList();
            cards.AddRange(communityCards.Cards);
            var collectiveCards = new Hand(cards);
            var details = GetHandValue(collectiveCards);
            return new HandDetails(hand, details.HandValue);
        }

        public abstract bool IsHandThis(Hand hand);

        public bool IsHandThis(Hand hand, Hand communityCards)
        {
            var cards = hand.Cards.ToList();
            cards.AddRange(communityCards.Cards);
            var collectiveCards = new Hand(cards);
            return IsHandThis(collectiveCards);
        }
    }
}
