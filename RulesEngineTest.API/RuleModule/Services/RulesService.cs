using RulesEngine.Interfaces;
using RulesEngine.Models;
using RulesEngineTest.API.RuleModule.Models;

namespace RulesEngineTest.API.RuleModule.Services
{
    public class RulesService(IRulesEngine rulesEngine)
    {
        private readonly IRulesEngine _rulesEngine = rulesEngine;
        public async Task<RuleCheckModel> CheckRuleAsync(string workflowName, dynamic[] inputs)
        {
            List<RuleResultTree> resultList = await _rulesEngine.ExecuteAllRulesAsync(workflowName, inputs);

            return HandleResult(resultList);
        }

        private static RuleCheckModel HandleResult(List<RuleResultTree> resultList)
        {
            List<string> errors = resultList
                .Where(result => !result.IsSuccess)
                .Select(result => result.ExceptionMessage)
                .ToList();

            return errors.Any()
                ? RuleCheckModel.CheckedOnFailure(errors)
                : RuleCheckModel.CheckedSuccessfully();
        }

    }
}
