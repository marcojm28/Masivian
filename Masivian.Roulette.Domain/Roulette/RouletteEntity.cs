using System;
using System.Collections.Generic;
using System.Text;

namespace Masivian.Roulette.Domain.Roulette
{
    [Serializable]
    public class RouletteEntity
    {
        public RouletteEntity()
        {
            this.Init();
        }

        public string Id { get; set; }
        public bool IsOpen { get; set; }
        public List<ListBet> Board { get; set; } = new List<ListBet>();
        private void Init()
        {
            for (int i = 0; i <= 37; i++)
            {
                Board.Add(new ListBet());
            }
        }
    }

    [Serializable]
    public class ListBet
    {
        public List<Bet> Bets { get; set; } = new List<Bet>();
    }

    [Serializable]
    public class Bet
    {
        public string IdUser { get; set; }
        public double Money { get; set; }
        public bool IsWinner { get; set; }
        public string BetType { get; set; }
        public string Color { get; set; }
    }
}
