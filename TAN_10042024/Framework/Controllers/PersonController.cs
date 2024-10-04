using Microsoft.AspNetCore.Mvc;
using TAN_10042024.Application.Abstractions;

namespace TAN_10042024.Framework.Controllers {
    [Route("api/person")]
    [ApiController, Produces("application/json")]
    public class PersonController : ControllerBase {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService) {
            _personService = personService;
        }

        [HttpGet, Route("{team}/max-score")]
        public IActionResult MaxScoreByTeam(string team) {
            var maxScore = _personService.GetMaxScoreByTeam(team);

            return Ok(new {
                result = maxScore
            });
        }

        [HttpGet, Route("{team}/second-least-score")]
        public IActionResult SecondLeastScoreByTeam(string team) {
            var secondToLeastScore = _personService.GetSecondToLeastScoreByTeam(team);

            return Ok(new {
                result = secondToLeastScore
            });
        }

        [HttpGet, Route("{team}/union-names")]
        public IActionResult UnionNamesByTeam(string team) {
            var commpaSeparatedUnionizedNames = _personService.UnionizePersonNamesByTeam(team);

            return Ok(new {
                result = commpaSeparatedUnionizedNames
            });
        }
    }
}
