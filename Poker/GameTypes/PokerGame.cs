using System;
using System.Collections.Generic;
using System.Text;
using Poker.Models;
using System.Linq;

namespace Poker.GameTypes
{
    public class PokerGame: AbstractGameType
    {
        private List<Hand> _hands;

        public PokerGame()
        {
            _hands = new List<Hand>();
        }

        public Hand FindWinningHand()
        {
            _hands.Where(hand => HandEvaluator.FindHandType(hand.cards) > _hands.FirstOrDefault(hand2 => hand != hand2 && HandEvaluators.FindHandType(hand2.cards))
        }
    }
}
