using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Masivian.Roulette.DTO.Roulette
{
    [Serializable]
    public class PlaceBetRequestDTO
    {
        public int Position { get; set; }
        public string Color { get; set; }
        public string BetType { get; set; }
        public double Money { get; set; }
        public string IdUser { get; set; }
        public string IdRoulette { get; set; }
    }
    public class PlaceBetResponseDTO
    {
        public string OperationState { get; set; }
    }
}
