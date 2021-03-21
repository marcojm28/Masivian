using Masivian.Roulette.DTO.Roulette;
using Masivian.Roulette.Domain.Roulette;
using System;
using System.Collections.Generic;
using System.Text;

namespace Masivian.Roulette.Interface.Repositories
{
    public interface IRouletteRepository
    {
        CreateRouletteResponseDTO CreateRoulette(RouletteEntity rouletteEntity);
        List<GetAllRouletteResponseDTO> GetAllRoulette();
        void UpdateRoulette(RouletteEntity openRouletteRequestDTO);
        RouletteEntity GetRouletteById(string id);
    }
}
