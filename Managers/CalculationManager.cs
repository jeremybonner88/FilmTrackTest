using LightBulbChallenge.Interfaces.Managers;
using LightBulbChallenge.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LightBulbChallenge.Managers
{
    public class CalculationManager<T> : ICalculationManager<T>
    {
        private readonly ICalculationService<T> _calculationService;

        public CalculationManager(ICalculationService<T> calculationService)
        {
            _calculationService = calculationService;
        }

        public async Task<IEnumerable<T>> SolveLightBulbProblem(int numberOfPeople, int numberOfLightBulbs)
        {
            return await _calculationService.SolveLightBulbProblem(numberOfPeople, numberOfLightBulbs);
        }
    }
}
