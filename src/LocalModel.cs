using LLama;
using LLama.Common;
using LLama.Sampling;


namespace NiloAI.src {

    class LocalModelParams {
        public uint contextSize = 1024;
        public int GPULayerCount = 5;

        public string modelPath = "";
    }

    class LocalModel {

        public readonly LLamaWeights model;
        public readonly LLamaContext context;
        public readonly InteractiveExecutor executor;

        public LocalModel(LocalModelParams parameters) {
            ModelParams P = new(parameters.modelPath)
            {
                ContextSize = parameters.contextSize,
                GpuLayerCount = parameters.GPULayerCount
            };
            
            
            model = LLamaWeights.LoadFromFile(P);
            context = model.CreateContext(P);
            executor = new(context);

        }
    }


}