using STEP_backend.Claims;
using System.Text.Json;

namespace STEP_backend.Services
{
    public class PromptService
    {
        private readonly PromptsJsonContainer _rawPrompts;
        public PromptService()
        {
            string jsonFilePath = "Static/prompts.json";
            string jsonString = File.ReadAllText(jsonFilePath);
            _rawPrompts = JsonSerializer.Deserialize<PromptsJsonContainer>(jsonString);
        }

        public async Task<string> GetGenerateTestPromptAsync(string topic, string material, int legth)
        {
            return await Task.Run(() =>
            {
                var raw = _rawPrompts.GenerateTestPrompt;
                var result = string.Format(raw, topic, material, legth);
                return result + _rawPrompts.TestFormatExample;
            });
        }

        public async Task<string> GetGenerateTopicPromptAsync(string topicName)
        {
            return await Task.Run(() =>
            {
                var raw = _rawPrompts.GenerateTestPrompt;
                var result = string.Format(raw, topicName);
                return result;
            });
        }

    }
}
