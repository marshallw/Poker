using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Poker.HandEvaluators;

namespace Poker.Models
{
    public class HandForecaster<T> where T: IHandEvaluator
    {
        private HandRanker<T> handRanker;
        private Deck deck;
        public HandForecaster()
        {
            handRanker = new HandRanker<T>();
            deck = new Deck();
        }

        public HandDetails FindStrongestHand(Hand hand)
        {
            List<Hand> hands = new List<Hand>();
            deck = Deck.GenerateDeck();

            foreach (var card in deck)
            {
                if (!hand.Cards.Contains(card))
                {
                    var newHand = new Hand(hand.Cards);
                    newHand.AddCard(card);
                    hands.Add(newHand);
                }
            }

            return hands.Select(_ => handRanker.RankHand(_)).OrderByDescending(_ => _).First();
        }
    }
}
