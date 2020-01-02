using Poker.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Poker.Exceptions;

namespace Poker.HandEvaluators
{
    public class HighCardEvaluator : IPokerHandEvaluator
    {
        public bool IsHandThis(Hand hand)
        {
            if (!IsHandThis(hand))
                throw new HandIsNotThisTypeException("Hand is not a Flush and cannot be evaluated");

            return hand.cards.OrderByDescending(x => x.CardValue).FirstOrDefault() != null;
        }

        public HandDetails GetHandValue(Hand hand)
        {
            var cardsInOrder = hand.cards.OrderByDescending(_ => _);
            return HandDetails.Create(hand, new HandValue(0, cardsInOrder));
        }
    }
}
