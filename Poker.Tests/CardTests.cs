using NUnit.Framework;
using Poker.Enums;
using Poker.Models;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(CardSuit.Heart, 13)]
        [TestCase(CardSuit.Club, 2)]
        [TestCase(CardSuit.Diamond, 5)]
        public void CardIsValid(CardSuit suit, int cardValue)
        {
            Card card = new Card(suit, cardValue);
            Assert.IsTrue(card.IsValid());
        }

        [TestCase(CardSuit.Spade, "ace")]
        [TestCase(CardSuit.Diamond, "a")]
        [TestCase(CardSuit.Club, "King")]
        [TestCase(CardSuit.Heart, "K")]
        [TestCase(CardSuit.Spade, "QUEEN")]
        [TestCase(CardSuit.Club, "q")]
        [TestCase(CardSuit.Heart, "JaCk")]
        [TestCase(CardSuit.Diamond, "J")]
        public void CreateCardWithName_IsValid(CardSuit suit, string cardvalue)
        {
            Card card = new Card(suit, cardvalue);
            Assert.IsTrue(card.IsValid());
        }

        [TestCase("Joker")]
        [TestCase("joker")]
        [TestCase("Land")]
        [TestCase("Kingy")]
        [TestCase("Black Lotus")]
        public void CreateCardWithName_NotValid(string cardValue)
        {
            Card card = new Card(CardSuit.Club, cardValue);
            Assert.IsFalse(card.IsValid());
          //  Assert.Throws<Exception>(card.IsValid());
        }

        [TestCase(CardSuit.Club, 14)]
        [TestCase(CardSuit.Diamond, 0)]
        public void CardIsNotValid(CardSuit suit, int cardValue)
        {
            Card card = new Card(suit, cardValue);
            Assert.IsFalse(card.IsValid());
        }
    }
}