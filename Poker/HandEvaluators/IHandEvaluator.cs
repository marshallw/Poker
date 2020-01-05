using System;
using System.Collections.Generic;
using System.Text;
using Poker.Models;
using System.Linq;

namespace Poker.HandEvaluators
{
    public interface IHandEvaluator
    {
        bool IsHandThis(Hand hand);
        bool IsHandThis(Hand hand, Hand communityCards);
        HandDetails GetHandRank(Hand hand);
        HandDetails GetHandRank(Hand hand, Hand communityCards);
    }
}
