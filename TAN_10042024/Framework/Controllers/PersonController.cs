using Microsoft.AspNetCore.Mvc;
using TAN_10042024.Application.Abstractions;

namespace TAN_10042024.Framework.Controllers
{
    [Route("api/person")]
    [ApiController, Produces("application/json")]
    public class PersonController : ControllerBase {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService) {
            _personService = personService;
        }

        [HttpGet, Route("{team}/max-score")]
        public async Task<IActionResult> MaxScoreByTeam(string team) {
            var maxScore = await _personService
                .GetMaxScoreByTeam(team);

            return Ok(new {
                success = true,
                data = maxScore
            });
        }

        [HttpGet, Route("{team}/second-least-score")]
        public async Task<IActionResult> SecondLeastScoreByTeam(string team) {
            var secondToLeastScore = await _personService
                .GetSecondToLeastScoreByTeam(team);

            return Ok(new {
                success = true,
                data = secondToLeastScore
            });
        }

        [HttpGet, Route("{team}/union-names")]
        public async Task<IActionResult> UnionNamesByTeam(string team) {
            var commpaSeparatedUnionizedNames = await _personService
                .UnionizePersonNamesByTeam(team);

            return Ok(new {
                success = true,
                data = commpaSeparatedUnionizedNames
            });
        }
    }
}
