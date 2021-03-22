using Masivian.Roulette.DTO.Roulette;
using System;
using System.Collections.Generic;
using System.Text;

namespace Masivian.Roulette.Interface.Services
{
    public interface IRouletteService
    {
        CreateRouletteResponseDTO CreateRoulette();
        OpenRouletteResponseDTO OpenRoulette(OpenRouletteRequestDTO openRouletteRequestDTO);
        PlaceBetResponseDTO PlaceBet(PlaceBetRequestDTO placeBetRequestDTO);
        CloseRouletteResponseDTO CloseRoulette(CloseRouletteRequestDTO closeRouletteRequestDTO);
        List<GetAllRouletteResponseDTO> GetAllRoulette();
    }
}
