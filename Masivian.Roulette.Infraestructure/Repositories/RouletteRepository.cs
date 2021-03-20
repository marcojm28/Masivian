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
        private const string KEYREDIS = "redis01";

        public RouletteRepository(IEasyCachingProviderFactory cachingProviderFactory)
        {
            this._cachingProviderFactory = cachingProviderFactory;
            this._cachingProvider = _cachingProviderFactory.GetCachingProvider(KEYREDIS);
        }

        public CreateRouletteResponseDTO CreateRoulette(RouletteEntity rouletteEntity)
        {
            _cachingProvider.Set(KEYREDIS + rouletteEntity.Id, rouletteEntity, TimeSpan.FromDays(365));
            CreateRouletteResponseDTO createRouletteResponseDTO = new CreateRouletteResponseDTO() {
                Id = rouletteEntity.Id
            };

            return createRouletteResponseDTO;
        }
    }
}
