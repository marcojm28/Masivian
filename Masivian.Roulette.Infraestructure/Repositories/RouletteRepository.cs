using EasyCaching.Core;
using Masivian.Roulette.Domain.Roulette;
using Masivian.Roulette.DTO.Roulette;
using Masivian.Roulette.Interface.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Masivian.Roulette.Infraestructure.Repositories
{
    public class RouletteRepository : IRouletteRepository
    {
        private IEasyCachingProvider _cachingProvider;
        private IEasyCachingProviderFactory _cachingProviderFactory;
        private const string KEYREDIS = "roulette";

        public RouletteRepository(IEasyCachingProviderFactory cachingProviderFactory)
        {
            this._cachingProviderFactory = cachingProviderFactory;
            this._cachingProvider = _cachingProviderFactory.GetCachingProvider(KEYREDIS);
        }

        public CreateRouletteResponseDTO CreateRoulette(RouletteEntity rouletteEntity)
        {
            _cachingProvider.Set(KEYREDIS + rouletteEntity.Id, rouletteEntity, TimeSpan.FromDays(365));

            return new CreateRouletteResponseDTO { Id = rouletteEntity.Id};
        }

        public List<GetAllRouletteResponseDTO> GetAllRoulette()
        {
            var getAllRouletteResponseDTOs = new List<GetAllRouletteResponseDTO>();
            var roulettes =_cachingProvider.GetByPrefix<RouletteEntity>(KEYREDIS);
            foreach (var item in roulettes) 
            {
                if (item.Value.HasValue) {
                    getAllRouletteResponseDTOs.Add(new GetAllRouletteResponseDTO { 
                        Id = item.Value.Value.Id,
                        IsOpen = item.Value.Value.IsOpen
                    });
                }
            }

            return getAllRouletteResponseDTOs;
        }
          
        public void UpdateRoulette(RouletteEntity rouletteEntity)
        {
            _cachingProvider.Set(KEYREDIS + rouletteEntity.Id, rouletteEntity, TimeSpan.FromDays(365));
        }

        public RouletteEntity GetRouletteById(string id)
        {
            var roulette = _cachingProvider.Get<RouletteEntity>(KEYREDIS + id);
            if (!roulette.HasValue)
            {
                return null;
            }

            return roulette.Value;
        }
    }
}
