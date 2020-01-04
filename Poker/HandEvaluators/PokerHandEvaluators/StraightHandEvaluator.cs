using Poker.EqualityComparers;
using Poker.Exceptions;
using Poker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Poker.HandEvaluators
{
    public class StraightHandEvaluator : BasePokerHandEvaluator
    {
        public override HandDetails GetHandValue(Hand hand)
        {
            if (!IsHandThis(hand))
                throw new HandIsNotThisTypeException("Hand is not a Straight and cannot be evaluated");

            //var highCard = hand.Cards.OrderByDescending(_ => _.CardValue).Distinct<Card>(new CardValueEqualityComparer()).First();
            List<Card> cards = hand.Cards.OrderBy(_ => _.CardValue).ToList();
            cards = cards.Distinct(new CardValueEqualityComparer()).Aggregate(new List<Card>(), (cards, next) =>
            {
                if (cards.Count() == 0)
                {
                    cards.Add(next);
                }
                else
                {
                    if (cards.Last().CardValue == next.CardValue - 1)
                    {
                        cards.Add(next);
                    }
                    else
                    {
                        if (cards.Count() < 5)
                        {
                            cards = new List<Card>();
                        }
                    }
                }
               
                return cards;
            });
            return new HandDetails(hand, new HandValue(4, cards.Last()));
        }

        public override bool IsHandThis(Hand hand)
        {
            var cardsTransform = hand.Cards.OrderBy(_ => _.CardValue).Select((i, j) => new Card(i.CardValue - j, i.CardSuit));
            return cardsTransform.Where(_ => _.CardValue == cardsTransform.First().CardValue).Count() >= 5 && cardsTransform.Distinct<Card>(new CardValueEqualityComparer()).Count() == 1;
        }
    }
}
