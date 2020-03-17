using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LightBulbChallenge.Interfaces.Managers
{
    public interface ICalculationManager<T>
    {
        Task<IEnumerable<T>> SolveLightBulbProblem(int numberOfPeople, int numberOfLightBulbs);
    }
}
