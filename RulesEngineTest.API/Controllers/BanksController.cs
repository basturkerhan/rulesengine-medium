using Microsoft.AspNetCore.Mvc;
using RulesEngine.Models;
using RulesEngineTest.API.DTOs;
using RulesEngineTest.API.Models;
using RulesEngineTest.API.RuleModule.Models;
using RulesEngineTest.API.RuleModule.Services;

namespace RulesEngineTest.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BanksController(RulesService rulesService) : ControllerBase
    {
        private readonly RulesService _rulesService = rulesService;

        [HttpPost]
        public async Task<IActionResult> Transfer(TransferRequestDto dto)
        {
            BankAccount account = new();
            dynamic[] inputs = [account, dto];
            RuleCheckModel ruleCheckModel = await _rulesService.CheckRuleAsync("Transfer", inputs);

            return (ruleCheckModel.IsSuccess) ? Ok() : BadRequest(ruleCheckModel.Errors);
        }


    }
}
