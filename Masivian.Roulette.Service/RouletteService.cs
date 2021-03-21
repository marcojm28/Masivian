using Masivian.Roulette.Domain.Roulette;
using Masivian.Roulette.DTO.Roulette;
using Masivian.Roulette.Interface.Repositories;
using Masivian.Roulette.Interface.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Masivian.Roulette.Service
{
    public class RouletteService : IRouletteService
    {
        private readonly IRouletteRepository _rouletteRepository;
        public RouletteService(IRouletteRepository rouletteRepository)
        {
            this._rouletteRepository = rouletteRepository;
        }
        public CreateRouletteResponseDTO CreateRoulette()
        {
            RouletteEntity rouletteEntity = new RouletteEntity()
            {
                Id = Guid.NewGuid().ToString(),
                IsOpen = false
            };
            _rouletteRepository.CreateRoulette(rouletteEntity);

            return new CreateRouletteResponseDTO { Id = rouletteEntity.Id };
        }
        public List<GetAllRouletteResponseDTO> GetAllRoulette()
        {
            return _rouletteRepository.GetAllRoulette();
        }

        public OpenRouletteResponseDTO OpenRoulette(OpenRouletteRequestDTO openRouletteRequestDTO)
        {
            var roulette = _rouletteRepository.GetRouletteById(openRouletteRequestDTO.Id);
            if (roulette == null)
            {
                throw new Exception("Roulette not exist");
            }
            else
            {
                if (roulette.IsOpen)
                {
                    return new OpenRouletteResponseDTO { OperationState = "Denied" };
                }

            }
            roulette.IsOpen = true;
            _rouletteRepository.UpdateRoulette(roulette);

            return new OpenRouletteResponseDTO { OperationState = "Success" };


        }
    }
}
