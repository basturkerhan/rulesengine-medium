namespace RulesEngineTest.API.RuleModule.Models
{
    public class RuleCheckModel
    {
        public bool IsSuccess { get; set; }
        public List<string>? Errors { get; set; }

        public static RuleCheckModel CheckedSuccessfully() => new() { IsSuccess = true };
        public static RuleCheckModel CheckedOnFailure(List<string> errors) => new() { IsSuccess = false, Errors = errors };

    }
}
