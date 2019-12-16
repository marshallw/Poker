using System;
using System.Collections.Generic;
using System.Text;
using Poker.Models;

namespace Poker.HandEvaluators
{
    interface IHandEvaluator
    {
        bool IsHandThis(Hand hand);
    }
}
