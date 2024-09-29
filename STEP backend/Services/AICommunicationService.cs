using Azure.AI.OpenAI;
using STEP_backend.Architecture.Services;
using STEP_backend.Models.Dtos.AIResponse;
using System.Text.Json;
namespace STEP_backend.Services
{
    public class AICommunicationService : IAICommunicationService
    {
        private readonly OpenAIClient _client;
        private readonly PromptService _promptService;
        public AICommunicationService(IConfiguration config)
        {
            _client = new OpenAIClient(config["gpt-key"]);
            _promptService = new PromptService();
        }

        public async Task<GenerateTestResponseDto> GenerateTestAsync(string topic, string material, int length = 5)
        {
            string prompt = await _promptService.GetGenerateTestPromptAsync(topic, material, length);

            var chatCompletionsOptions = new ChatCompletionsOptions
            {
                DeploymentName = "gpt-4o",
                Temperature = (float)1,
                MaxTokens = 800,
                FrequencyPenalty = 0,
                PresencePenalty = 0
            };

            chatCompletionsOptions.Messages.Add(new ChatRequestSystemMessage(prompt));
            var response = await _client.GetChatCompletionsAsync(chatCompletionsOptions);
            var responseStr = response.Value.Choices[0].Message.Content;
            try
            {
                var questions = JsonSerializer.Deserialize<List<GenerateTestQuestion>>(responseStr);

                if (questions == null)
                    throw new Exception("Bad JSON Test format from OpenAi");
                return new GenerateTestResponseDto() { Questions = questions };
            }
            catch (Exception)
            {
                throw new Exception("Bad JSON Test format from OpenAi");
                throw;
            }
        }

        public async Task<GenerateTopicResponseDto> GenerateTeachMaterialByTopic(string topicName)
        {
            string prompt = await _promptService.GetGenerateTopicPromptAsync(topicName);

            var chatCompletionsOptions = new ChatCompletionsOptions
            {
                DeploymentName = "gpt-3.5-turbo",
                Temperature = (float)1,
                MaxTokens = 800,
                FrequencyPenalty = 0,
                PresencePenalty = 0
            };

            chatCompletionsOptions.Messages.Add(new ChatRequestSystemMessage(prompt));
            var response = await _client.GetChatCompletionsAsync(chatCompletionsOptions);
            var responseStr = response.Value.Choices[0].Message.Content;
            return new GenerateTopicResponseDto() { Topic = topicName, Material = responseStr };
        }
    }
}
