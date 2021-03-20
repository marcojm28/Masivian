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
        public List<Bet> Board { get; set; } = new List<Bet>();
        private void Init()
        {
            for (int i = 0; i < 36; i++)
            {
                Board.Add(new Bet());
            }
        }
    }

    [Serializable]
    public class Bet
    {
        public string IdUser { get; set; }
        public double Money { get; set; }
        public string BetType { get; set; }

    }
}
