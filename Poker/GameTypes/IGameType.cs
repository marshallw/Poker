using System;
using System.Collections.Generic;
using System.Text;
using Poker.Models;

namespace Poker.GameTypes
{
    interface IGameType
    {
        void AddHand(Hand hand);
        Hand FindWinningHand();
    }
}
