using Masivian.Roulette.Domain.Roulette;
using Masivian.Roulette.DTO.Roulette;
using Masivian.Roulette.Interface.Repositories;
using Masivian.Roulette.Interface.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Masivian.Roulette.Service
{
    public class RouletteService: IRouletteService
    {
        private readonly IRouletteRepository _rouletteRepository;
        public RouletteService(IRouletteRepository rouletteRepository)
        {
            this._rouletteRepository = rouletteRepository;
        }
        public CreateRouletteResponseDTO CreateRoulette()
        {
            CreateRouletteResponseDTO createRouletteResponseDTO = new CreateRouletteResponseDTO()
            {
                Id = Guid.NewGuid().ToString()
            };
            RouletteEntity rouletteEntity = new RouletteEntity()
            {
                Id = createRouletteResponseDTO.Id,
                IsOpen = false
            };
            _rouletteRepository.CreateRoulette(rouletteEntity);

            return createRouletteResponseDTO;
        }
    }
}
