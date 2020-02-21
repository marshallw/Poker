using Poker.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Poker.Exceptions;

namespace Poker.HandEvaluators
{
    public class HighCardEvaluator : BasePokerHandEvaluator
    {
        public override bool IsHandThis(Hand hand)
        {
            return hand.Cards.OrderByDescending(x => x.CardValue).FirstOrDefault() != null;
        }

        public override HandDetails GetHandRank(Hand hand)
        {
            if (!IsHandThis(hand))
                throw new HandIsNotThisTypeException("Card has no high cards; are there even any cards?");

            var cardsInOrder = hand.Cards.OrderByDescending(_ => _)
                                         .Where((i, j) => j <= 4);

            return HandDetails.Create(hand, new HandValue(0, cardsInOrder));
        }
    }
}
