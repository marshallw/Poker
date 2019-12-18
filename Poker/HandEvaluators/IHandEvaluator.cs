using System;
using System.Collections.Generic;
using System.Text;
using Poker.Models;
using System.Linq;

namespace Poker.HandEvaluators
{
    interface IHandEvaluator
    {
         bool IsHandThis(Hand hand);
        HandValue GetHandValue(Hand hand);
    }
}
