using Microsoft.AspNetCore.Mvc;
using Clean.Architecture.API.Application.Abstractions;

namespace Clean.Architecture.API.Framework.APIs.Controllers {
    [Route("api/person")]
    [ApiController, Produces("application/json")]
    public class PersonController : ControllerBase {
        private readonly IPerson _personService;

        public PersonController(IPerson personService) {
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
