using Newtonsoft.Json;
using RulesEngine.Models;

namespace RulesEngineTest.API.RuleModule.Helpers
{
    public class RuleFileReader
    {
        public static List<Workflow>? LoadWorkflowsFromFile(string filePath)
        {
            var fileData = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<Workflow>>(fileData);
        }

        public static string[] GetRuleFiles(string folderPath)
        {
            return Directory.GetFiles(folderPath);
        }
    }

}
