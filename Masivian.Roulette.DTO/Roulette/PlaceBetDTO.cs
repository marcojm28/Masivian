using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Masivian.Roulette.DTO.Roulette
{
    public class PlaceBetRequestDTO
    {
        [Range(0, 36)]
        public int Position { get; set; }
        public string Color { get; set; }
        public string BetType { get; set; }
        [Range(0.5d, maximum: 10000)]
        public double Money { get; set; }
        public string IdUser { get; set; }
    }
    public class PlaceBetResponseDTO
    {

    }
}
