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
                throw new Exception(Common.Enum.Message.rouletteNotExist);
            }
            else
            {
                if (roulette.IsOpen)
                {
                    return new OpenRouletteResponseDTO { OperationState = Common.Enum.Message.denied };
                }

            }
            roulette.IsOpen = true;
            _rouletteRepository.UpdateRoulette(roulette);

            return new OpenRouletteResponseDTO { OperationState = Common.Enum.Message.success };
        }
        public PlaceBetResponseDTO PlaceBet(PlaceBetRequestDTO placeBetRequestDTO)
        {
            ValidateBet(placeBetRequestDTO);
            var roulette = _rouletteRepository.GetRouletteById(placeBetRequestDTO.IdRoulette);
            if (roulette == null)
            {
                throw new Exception(Common.Enum.Message.rouletteNotExist);
            }
            else
            {
                if (!roulette.IsOpen)
                {
                    throw new Exception(Common.Enum.Message.validateRouletteClosed);
                }
            }
            roulette.Board[placeBetRequestDTO.BetType == Common.Enum.BetType.number ? placeBetRequestDTO.Position : Common.Enum.BetType.positionForBetColor].Bets.Add(new Bet {
                IdUser = placeBetRequestDTO.IdUser,
                BetType = placeBetRequestDTO.BetType,
                Color = placeBetRequestDTO.Color,
                Money = placeBetRequestDTO.Money
            });
            _rouletteRepository.UpdateRoulette(roulette);

            return new PlaceBetResponseDTO { OperationState = Common.Enum.Message.success };
        }

        #region private methods
        private void ValidateBet(PlaceBetRequestDTO placeBetRequestDTO)
        {
            ValidateBetType(placeBetRequestDTO.BetType);
            ValidateBetMoney(placeBetRequestDTO.Money);
            ValidateIdUser(placeBetRequestDTO.IdUser);
            if (placeBetRequestDTO.BetType == Common.Enum.BetType.color)
            {
                ValidateBetColor(placeBetRequestDTO.Color);
            }
            else 
            {
                if (placeBetRequestDTO.BetType == Common.Enum.BetType.number)
                {
                    ValidateBetPositionRoulette(placeBetRequestDTO.Position);
                }
            }
        }
        private void ValidateBetType(string betType)
        {
            if (string.IsNullOrEmpty(betType))
            {
                throw new Exception(Common.Enum.Message.validateBetType);
            }
            else
            {
                if (betType != Common.Enum.BetType.color && betType != Common.Enum.BetType.number)
                {
                    throw new Exception(Common.Enum.Message.validateBetType);
                }
            }
        }
        private void ValidateBetColor(string color)
        {
            if (string.IsNullOrEmpty(color))
            {
                throw new Exception(Common.Enum.Message.validateBetColor);
            }
            else
            {
                if (color != Common.Enum.Color.black && color != Common.Enum.Color.red)
                {
                    throw new Exception(Common.Enum.Message.validateBetColor);
                }
            }
        }
        private void ValidateBetPositionRoulette(int positionRoulette)
        {
            if (positionRoulette < 0 || positionRoulette > 36)
            {
                throw new Exception(Common.Enum.Message.positionOutRange);
            }
        }
        private void ValidateBetMoney(double bet)
        {
            if (bet < 0.5d || bet > 10000)
            {
                throw new Exception(Common.Enum.Message.betOutRange);
            }
        }
        private void ValidateIdUser(string idUser) 
        {
            if (string.IsNullOrEmpty(idUser))
            {
                throw new Exception(Common.Enum.Message.validateBetIdUser);
            }
        }
        #endregion
    }
}
