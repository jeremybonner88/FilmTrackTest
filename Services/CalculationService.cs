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

            bool IsEqualPeopleAndBulbs = numberOfPeople == numberOfLightBulbs;
            //solution is a simple sqrt factor if number of people = number of lightbulbs

            if (IsEqualPeopleAndBulbs)
            {
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
            }
            else if(numberOfPeople > 0 && numberOfLightBulbs > 0)
            {
                Dictionary<int, bool> bulbNumberWithCountDict = new Dictionary<int, bool>();
                for(int person = 1; person<=numberOfPeople; person++)
                {
                    for(int bulb = 1; bulb<=numberOfLightBulbs; bulb++)
                    {
                        //initiate first pass
                        if (person == 1)
                            bulbNumberWithCountDict.Add(bulb, true);
                        else if(bulb % person == 0) //check if person will hit it
                        {
                            if (bulbNumberWithCountDict.ContainsKey(bulb))
                                bulbNumberWithCountDict[bulb] = !bulbNumberWithCountDict[bulb];
                            else
                                bulbNumberWithCountDict.Add(bulb, true);
                        }
                        //what if user has more bulbs than people
                        else if((bulb < person) && person % bulb == 0)
                        {
                            if (bulbNumberWithCountDict.ContainsKey(bulb))
                                bulbNumberWithCountDict[bulb] = !bulbNumberWithCountDict[bulb];
                            else
                                bulbNumberWithCountDict.Add(bulb, true);
                        }
                    }
                }
                var litBulbsToReport = bulbNumberWithCountDict.Where(x => x.Value == true);
                foreach(var bulb in litBulbsToReport)
                {
                    resultList.Add("Light bulb: " + bulb.Key.ToString() + " is on");
                }
                resultList.Add("Total Lit Bulbs: " + litBulbsToReport.Where(x=>x.Value == true).Count());
            }
            else
            {
                resultList.Add("Please make sure that Number of People and Number of Light Bulbs is greater than 0");
            }
            return await Task.FromResult(resultList.Cast<T>());
        }
    }
}
