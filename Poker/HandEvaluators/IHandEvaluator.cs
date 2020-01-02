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
        HandDetails GetHandValue(Hand hand);
    }
}
