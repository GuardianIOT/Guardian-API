using Microsoft.ML.Data;
using Microsoft.ML;

namespace Guardian_API.Application.Services
{

    public class ClimaPredictionService
    {
        private readonly ITransformer _modelo;
        private readonly MLContext _mlContext;

        public ClimaPredictionService()
        {
            _mlContext = new MLContext();
            _modelo = CriarModelo(); 
        }

        private ITransformer CriarModelo()
        {
            var dadosExemplo = new List<ClimaData>
        {
            new ClimaData { Temperatura = 25f, Umidade = 80f, VelocidadeVento = 15f, Precipitacao = 10f },
            new ClimaData { Temperatura = 30f, Umidade = 60f, VelocidadeVento = 20f, Precipitacao = 5f },
            new ClimaData { Temperatura = 20f, Umidade = 90f, VelocidadeVento = 10f, Precipitacao = 15f },
        };

            var dados = _mlContext.Data.LoadFromEnumerable(dadosExemplo);

            var pipeline = _mlContext.Transforms.Concatenate("Features",
                    nameof(ClimaData.Temperatura),
                    nameof(ClimaData.Umidade),
                    nameof(ClimaData.VelocidadeVento))
                .Append(_mlContext.Regression.Trainers.Sdca(
                    labelColumnName: nameof(ClimaData.Precipitacao),
                    featureColumnName: "Features"));

            return pipeline.Fit(dados);
        }

        public float PreverPrecipitacao(float temperatura, float umidade, float velocidadeVento)
        {
            var dadosEntrada = new ClimaData
            {
                Temperatura = temperatura,
                Umidade = umidade,
                VelocidadeVento = velocidadeVento
            };

            var engine = _mlContext.Model.CreatePredictionEngine<ClimaData, ClimaPrediction>(_modelo);
            var predicao = engine.Predict(dadosEntrada);

            return predicao.Precipitacao;
        }
    }

    public class ClimaData
    {
        public float Temperatura { get; set; }
        public float Umidade { get; set; }
        public float VelocidadeVento { get; set; }
        public float Precipitacao { get; set; }
    }

    public class ClimaPrediction
    {
        public float Precipitacao { get; set; }
    }

}
