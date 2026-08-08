using LLama;
using LLama.Common;
using LLama.Sampling;

namespace NiloAI.src
{
    class NiloChat
    {
        public readonly LocalModel modelService;
        public ChatHistory chatHistory;
        public readonly ChatSession chatSession;

        public readonly InferenceParams inferenceParams; 



        public NiloChat(string path)
        {
            var P = new LocalModelParams
            {
                contextSize = 2048,
                GPULayerCount = 5,
                modelPath = path
            };

            modelService = new LocalModel(P);

            inferenceParams = new InferenceParams
            {
                MaxTokens = 1024,
                SamplingPipeline = new DefaultSamplingPipeline()
            };

            const string startingPrompt= "";
            
            chatHistory = new ChatHistory();
            chatHistory.AddMessage(AuthorRole.System, startingPrompt);

            chatSession = new(modelService.executor, chatHistory);
        }

        public async Task<string> GetAIAnswer(string userInput)
        {
            string res = "";

            var S = chatSession.ChatAsync(new ChatHistory.Message(AuthorRole.User, userInput), inferenceParams);

            await foreach (var text in S)
            {
                res += text;
            }

            return res;
        }

    }

}