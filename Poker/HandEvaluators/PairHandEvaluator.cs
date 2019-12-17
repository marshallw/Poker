using System;
using System.Collections.Generic;
using System.Text;
using Poker.Models;
using System.Linq;

namespace Poker.HandEvaluators
{
    public class PairHandEvaluator : IPokerHandEvaluator
    {
        public bool IsHandThis(Hand hand) => hand.cards.Any(x => hand.cards.Any(y => y.CardValue == x.CardValue && y != x));
    }
}
