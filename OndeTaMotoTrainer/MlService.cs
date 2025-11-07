using Microsoft.ML;
using Microsoft.ML.Data;
using System.Collections.Generic;

namespace OndeTaMotoTrainer
{
   
    public class MlService
    {
        private readonly MLContext _mlContext;
        private readonly ITransformer _model;

        public MlService()
        {
            _mlContext = new MLContext(seed: 0);

            var trainingData = new List<MotoData>
            {
                new MotoData { Kilometers = 1000f, AgeYears = 0.5f, NeedsService = false },
                new MotoData { Kilometers = 5000f, AgeYears = 1f, NeedsService = false },
                new MotoData { Kilometers = 8000f, AgeYears = 1.5f, NeedsService = false },
                new MotoData { Kilometers = 15000f, AgeYears = 2f, NeedsService = true },
                new MotoData { Kilometers = 25000f, AgeYears = 3f, NeedsService = true },
                new MotoData { Kilometers = 40000f, AgeYears = 5f, NeedsService = true },
                new MotoData { Kilometers = 60000f, AgeYears = 6f, NeedsService = true },
                new MotoData { Kilometers = 3000f, AgeYears = 0.8f, NeedsService = false }
            };

            var dataView = _mlContext.Data.LoadFromEnumerable(trainingData);

            var pipeline = _mlContext.Transforms.Concatenate("Features", nameof(MotoData.Kilometers), nameof(MotoData.AgeYears))
                .Append(_mlContext.Transforms.NormalizeMinMax("Features"))
                .Append(_mlContext.BinaryClassification.Trainers.SdcaLogisticRegression(
                    labelColumnName: nameof(MotoData.NeedsService),
                    featureColumnName: "Features"));

            _model = pipeline.Fit(dataView);
        }

        
        public MotoPrediction Predict(float kilometers, float ageYears)
        {
            var engine = _mlContext.Model.CreatePredictionEngine<MotoData, MotoPrediction>(_model);
            return engine.Predict(new MotoData { Kilometers = kilometers, AgeYears = ageYears });
        }

        private class MotoData
        {
            public float Kilometers { get; set; }
            public float AgeYears { get; set; }
            public bool NeedsService { get; set; }
        }

        public class MotoPrediction
        {
            [ColumnName("PredictedLabel")]
            public bool PredictedLabel { get; set; }
            public float Probability { get; set; }
            public float Score { get; set; }
        }
    }
}

