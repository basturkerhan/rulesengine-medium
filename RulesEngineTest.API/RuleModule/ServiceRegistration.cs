using RulesEngine;
using RulesEngine.Interfaces;
using RulesEngine.Models;
using RulesEngineTest.API.RuleModule.CustomMethods;
using RulesEngineTest.API.RuleModule.Helpers;
using RulesEngineTest.API.RuleModule.Services;
using System.Reflection;

namespace RulesEngineTest.API.RuleModule
{
    public static class ServiceRegistration
    {
        private static readonly string RULES_FOLDER_PATH = Path.Combine(Directory.GetCurrentDirectory(), "Rules");
        public static void AddRuleSystem(this IServiceCollection services)
        {
            services.AddSingleton(sp =>
            {
                string[] ruleFiles = RuleFileReader.GetRuleFiles(RULES_FOLDER_PATH);
                List<Workflow>? workflows = ruleFiles.SelectMany(filePath => RuleFileReader.LoadWorkflowsFromFile(filePath) ?? []).ToList();
                ReSettings reSettingsWithCustomTypes = new()
                {
                    CustomTypes = [typeof(TestMethods)]
                };
                IRulesEngine ruleEngine = new RulesEngine.RulesEngine([.. workflows], reSettingsWithCustomTypes);

                

                return new RulesService(ruleEngine);
            });
        }

    }
}
