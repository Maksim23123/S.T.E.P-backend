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
                DeploymentName = "gpt-4o",
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

        public async Task<GenerateTeachMarkResponseDto> GenerateTeachMark(string sentence, string topicName, string material)
        {
            string prompt = await _promptService.GetGenerateTeachMarkPromptAsync(sentence, topicName, material);

            var chatCompletionsOptions = new ChatCompletionsOptions
            {
                DeploymentName = "gpt-4o",
                Temperature = (float)1,
                MaxTokens = 20,
                FrequencyPenalty = 0,
                PresencePenalty = 0
            };

            chatCompletionsOptions.Messages.Add(new ChatRequestSystemMessage(prompt));
            var response = await _client.GetChatCompletionsAsync(chatCompletionsOptions);
            var responseStr = response.Value.Choices[0].Message.Content;
            try
            {
                var mark = JsonSerializer.Deserialize<GenerateTeachMarkResponseDto>(responseStr);

                if (mark == null)
                    throw new Exception("Bad JSON Test format from OpenAi");
                return mark;
            }
            catch (Exception)
            {
                throw new Exception("Bad JSON Test format from OpenAi");
                throw;
            }
        }
    }
}
