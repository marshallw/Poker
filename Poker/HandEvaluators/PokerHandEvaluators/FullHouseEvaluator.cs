using Poker.EqualityComparers;
using Poker.Exceptions;
using Poker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Poker.HandEvaluators
{
    public class FullHouseEvaluator : IPokerHandEvaluator
    {
        public HandDetails GetHandValue(Hand hand)
        {
            if (!IsHandThis(hand))
                throw new HandIsNotThisTypeException("Hand is not a Full House and cannot be evaluated");

            var highCard = hand.cards.GroupBy(_ => _.CardValue).OrderByDescending(_ => _.Count())
                                    .Where(_ => _.Count() == 3).First().First();
            var cards = new List<Card>(new Card[] { highCard });
            cards.Add(hand.cards.Where(_ => _.CardValue != highCard.CardValue).GroupBy(_ => _.CardValue)
                                .Where(_ => _.Count() >= 2).SelectMany(_ => _).OrderByDescending(_ => _.CardValue).First());
            return new HandDetails(hand, new HandValue(6, cards));
        }

        public bool IsHandThis(Hand hand)
        {
            return hand.cards.GroupBy(_ => _.CardValue).Any(_ => _.Count() == 2) && 
                   hand.cards.GroupBy(_ => _.CardValue).Any(_ => _.Count() == 3);
        }
    }
}
