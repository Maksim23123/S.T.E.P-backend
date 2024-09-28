using STEP_backend.Models.Dtos.AIResponse;

namespace STEP_backend.Architecture.Services
{
    public interface IAICommunicationService
    {
        public Task<GenerateTestResponseDto> GenerateTestAsync(string topic, string material, int length = 5);
        public Task<GenerateTopicResponseDto> GenerateTeachMaterialByTopic(string topicName);

    }
}
