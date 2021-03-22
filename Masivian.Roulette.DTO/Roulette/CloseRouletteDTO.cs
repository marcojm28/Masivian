using System;
using System.Collections.Generic;
using System.Text;

namespace Masivian.Roulette.DTO.Roulette
{
    public class CloseRouletteRequestDTO
    {
        public string Id { get; set; }
    }
    public class CloseRouletteResponseDTO
    {
        public int NumberWinner { get; set; }
        public string ColorWinner { get; set; }
        public List<Winners> Winners { get; set; } = new List<Winners>();
    }
    public class Winners 
    {
        public string IdUser { get; set; }
        public double Bet { get; set; }
        public double TotalProfit { get; set; }
    }
}
