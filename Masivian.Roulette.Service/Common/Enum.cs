using System;
using System.Collections.Generic;
using System.Text;

namespace Masivian.Roulette.Service.Common
{
    public class Enum
    {
        public struct Message 
        {
            public const string success = "Success";
            public const string denied = "Denied";
            public const string rouletteNotExist = "Roulette not exist";
            public const string betOutRange = "Bet out of range";
            public const string positionOutRange = "Position out of range";
            public const string validateBetType = "You should select the type of bet, 'C' for color or 'N' for number";
            public const string validateBetColor = "You should select color, 'R' for Red or 'B' for Black";
            public const string validateBetIdUser = "You must send the user id";
            public const string validateRouletteClosed = "Roulette is closed";
        }
        public struct BetType
        {
            public const string number = "N";
            public const string color = "C";
            public const int positionForBetColor = 37;
        }
        public struct Color
        {
            public const string black = "B";
            public const string red = "R";
        }
    }
}
