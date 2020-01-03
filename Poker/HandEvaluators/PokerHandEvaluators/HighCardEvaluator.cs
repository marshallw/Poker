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
            return hand.cards.OrderByDescending(x => x.CardValue).FirstOrDefault() != null;
        }

        public HandDetails GetHandValue(Hand hand)
        {
            if (!IsHandThis(hand))
                throw new HandIsNotThisTypeException("Card has no high cards; are there even any cards?");

            var cardsInOrder = hand.cards.OrderByDescending(_ => _).Where((i, j) => j <= 4);

            return HandDetails.Create(hand, new HandValue(0, cardsInOrder));
        }
    }
}
