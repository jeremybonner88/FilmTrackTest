using LightBulbChallenge.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LightBulbChallenge.Services
{
    public class CalculationService<T> : ICalculationService<T>
    {
        //if I was connecting to repository here is where i would declare for dependancy injection
        //since the calculation won't change if inputs are repeated, we can store in memory
        public CalculationService()
        {

        }
        public async Task<IEnumerable<T>> SolveLightBulbProblem(int numberOfPeople, int numberOfLightBulbs)
        {
            //initialize the return resultset
            var resultList = new List<string>();

            // initialize final count
            int litBulbs = 0;

            // bulb number iterator
            int bulbNumber = 1;

            // person iterator
            int personNumber = 1;

            // check if factor of lightbulb is on or not
            for (bulbNumber = 1; bulbNumber <= numberOfLightBulbs; bulbNumber++)
            {

                // inner loop used to find factors of given bulb
                // used to count number of factors of the bulb
                int factors = 0;

                for (personNumber = 1; (personNumber * personNumber <= numberOfLightBulbs && personNumber <= numberOfPeople); personNumber++)
                {

                    if (bulbNumber % personNumber == 0) //check if person will hit it
                    {
                        factors++;

                        // final check that bulb != person*person 
                        if (bulbNumber / personNumber != personNumber)
                        {
                            factors++;
                        }
                    }
                }

                // if factor number is nodd
                if (factors % 2 == 1)
                {
                    // light ends as on state
                    resultList.Add("Light bulb: " + bulbNumber + " is on");
                    litBulbs++;
                }
            }

            resultList.Add("Total Lit Bulbs: " + litBulbs.ToString());
            return await Task.FromResult(resultList.Cast<T>());
        }
    }
}
