using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LightBulbChallenge.Interfaces.Managers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LightBulbChallenge.Controllers
{
    [Route("api/[controller]")]
    public class CalculationController : Controller
    {
        private readonly ICalculationManager<string> _calculationManager;

        public CalculationController(ICalculationManager<string> calculationManager)
        {
            _calculationManager = calculationManager;
        }
        [HttpGet]
        [Route("SolveLightBulbProblem/{numberOfPeople}/{numberOfLightbulbs}")]
        public async Task<ActionResult> SolveLightBulbProblem(int numberOfPeople, int numberOfLightbulbs)
        {
            try
            {
                return Json(await _calculationManager.SolveLightBulbProblem(numberOfPeople, numberOfLightbulbs));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}