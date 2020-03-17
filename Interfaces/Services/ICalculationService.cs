using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LightBulbChallenge.Interfaces.Services
{
    public interface ICalculationService<T>
    {
        Task<IEnumerable<T>> SolveLightBulbProblem(int numberOfPeople, int numberOfLightBulbs);
    }
}
