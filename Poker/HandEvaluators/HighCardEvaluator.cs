using Poker.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace Poker.HandEvaluators
{
    public class HighCardEvaluator : IPokerHandEvaluator
    {
        public HandValue GetHandValue(Hand hand)
        {
            Card highCard = hand.cards.OrderByDescending(x => x.CardValue).FirstOrDefault();
            HandValue result = new HandValue("0", "");

            return result;

        }

        public bool IsHandThis(Hand hand)
        {
            return hand.cards.OrderByDescending(x => x.CardValue).FirstOrDefault() != null;
        }
    }
}
