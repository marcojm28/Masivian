using Masivian.Roulette.DTO.Roulette;
using System;
using System.Collections.Generic;
using System.Text;

namespace Masivian.Roulette.Interface.Services
{
    public interface IRouletteService
    {
        CreateRouletteResponseDTO CreateRoulette();
        List<GetAllRouletteResponseDTO> GetAllRoulette();
        OpenRouletteResponseDTO OpenRoulette(OpenRouletteRequestDTO openRouletteRequestDTO);
        PlaceBetResponseDTO PlaceBet(PlaceBetRequestDTO placeBetRequestDTO);
    }
}
