
using Microsoft.ML;
using MottuWebApplication.Trainer;
using System;
using System.Collections.Generic;

Console.WriteLine("Iniciando Treinamento do Modelo de Manutenção...");

var sampleData = new List<ModelInput>
{
    // 1-25: baixos (espera-se NAO precisa)
    new ModelInput { KmRodados = 0f, DiasDesdeUltimaManutencao = 0f, PrecisaManutencao = false },
    new ModelInput { KmRodados = 50f, DiasDesdeUltimaManutencao = 5f, PrecisaManutencao = false },
    new ModelInput { KmRodados = 100f, DiasDesdeUltimaManutencao = 10f, PrecisaManutencao = false },
    new ModelInput { KmRodados = 200f, DiasDesdeUltimaManutencao = 15f, PrecisaManutencao = false },
    new ModelInput { KmRodados = 300f, DiasDesdeUltimaManutencao = 20f, PrecisaManutencao = false },
    new ModelInput { KmRodados = 400f, DiasDesdeUltimaManutencao = 30f, PrecisaManutencao = false },
    new ModelInput { KmRodados = 600f, DiasDesdeUltimaManutencao = 45f, PrecisaManutencao = false },
    new ModelInput { KmRodados = 800f, DiasDesdeUltimaManutencao = 60f, PrecisaManutencao = false },
    new ModelInput { KmRodados = 900f, DiasDesdeUltimaManutencao = 10f, PrecisaManutencao = false },
    new ModelInput { KmRodados = 1200f, DiasDesdeUltimaManutencao = 20f, PrecisaManutencao = false },
    new ModelInput { KmRodados = 1500f, DiasDesdeUltimaManutencao = 30f, PrecisaManutencao = false },
    new ModelInput { KmRodados = 1800f, DiasDesdeUltimaManutencao = 40f, PrecisaManutencao = false },
    new ModelInput { KmRodados = 1900f, DiasDesdeUltimaManutencao = 50f, PrecisaManutencao = false },
    new ModelInput { KmRodados = 2000f, DiasDesdeUltimaManutencao = 20f, PrecisaManutencao = false },
    new ModelInput { KmRodados = 2100f, DiasDesdeUltimaManutencao = 55f, PrecisaManutencao = false },
    new ModelInput { KmRodados = 2200f, DiasDesdeUltimaManutencao = 5f, PrecisaManutencao = false },
    new ModelInput { KmRodados = 2500f, DiasDesdeUltimaManutencao = 35f, PrecisaManutencao = false },
    new ModelInput { KmRodados = 2700f, DiasDesdeUltimaManutencao = 60f, PrecisaManutencao = false },
    new ModelInput { KmRodados = 2800f, DiasDesdeUltimaManutencao = 10f, PrecisaManutencao = false },
    new ModelInput { KmRodados = 500f, DiasDesdeUltimaManutencao = 2f, PrecisaManutencao = false },
    new ModelInput { KmRodados = 1600f, DiasDesdeUltimaManutencao = 25f, PrecisaManutencao = false },
    new ModelInput { KmRodados = 1300f, DiasDesdeUltimaManutencao = 15f, PrecisaManutencao = false },
    new ModelInput { KmRodados = 700f, DiasDesdeUltimaManutencao = 7f, PrecisaManutencao = false },
    new ModelInput { KmRodados = 350f, DiasDesdeUltimaManutencao = 12f, PrecisaManutencao = false },
    new ModelInput { KmRodados = 950f, DiasDesdeUltimaManutencao = 18f, PrecisaManutencao = false },

    // 26-50: médios (mistura de true/false)
    new ModelInput { KmRodados = 3000f, DiasDesdeUltimaManutencao = 90f, PrecisaManutencao = false },
    new ModelInput { KmRodados = 3200f, DiasDesdeUltimaManutencao = 120f, PrecisaManutencao = false },
    new ModelInput { KmRodados = 3500f, DiasDesdeUltimaManutencao = 140f, PrecisaManutencao = false },
    new ModelInput { KmRodados = 3800f, DiasDesdeUltimaManutencao = 160f, PrecisaManutencao = true },
    new ModelInput { KmRodados = 4000f, DiasDesdeUltimaManutencao = 45f, PrecisaManutencao = false },
    new ModelInput { KmRodados = 4200f, DiasDesdeUltimaManutencao = 75f, PrecisaManutencao = false },
    new ModelInput { KmRodados = 4500f, DiasDesdeUltimaManutencao = 95f, PrecisaManutencao = false },
    new ModelInput { KmRodados = 4800f, DiasDesdeUltimaManutencao = 130f, PrecisaManutencao = true },
    new ModelInput { KmRodados = 5000f, DiasDesdeUltimaManutencao = 180f, PrecisaManutencao = true },
    new ModelInput { KmRodados = 5200f, DiasDesdeUltimaManutencao = 10f, PrecisaManutencao = false },
    new ModelInput { KmRodados = 5400f, DiasDesdeUltimaManutencao = 200f, PrecisaManutencao = true },
    new ModelInput { KmRodados = 5600f, DiasDesdeUltimaManutencao = 50f, PrecisaManutencao = false },
    new ModelInput { KmRodados = 5800f, DiasDesdeUltimaManutencao = 85f, PrecisaManutencao = false },
    new ModelInput { KmRodados = 6000f, DiasDesdeUltimaManutencao = 210f, PrecisaManutencao = true },
    new ModelInput { KmRodados = 6200f, DiasDesdeUltimaManutencao = 155f, PrecisaManutencao = true },
    new ModelInput { KmRodados = 6400f, DiasDesdeUltimaManutencao = 45f, PrecisaManutencao = false },
    new ModelInput { KmRodados = 6600f, DiasDesdeUltimaManutencao = 300f, PrecisaManutencao = true },
    new ModelInput { KmRodados = 6800f, DiasDesdeUltimaManutencao = 120f, PrecisaManutencao = true },
    new ModelInput { KmRodados = 7000f, DiasDesdeUltimaManutencao = 10f, PrecisaManutencao = false },
    new ModelInput { KmRodados = 7200f, DiasDesdeUltimaManutencao = 95f, PrecisaManutencao = true },
    new ModelInput { KmRodados = 7400f, DiasDesdeUltimaManutencao = 160f, PrecisaManutencao = true },
    new ModelInput { KmRodados = 7600f, DiasDesdeUltimaManutencao = 40f, PrecisaManutencao = false },
    new ModelInput { KmRodados = 7800f, DiasDesdeUltimaManutencao = 20f, PrecisaManutencao = false },
    new ModelInput { KmRodados = 8000f, DiasDesdeUltimaManutencao = 365f, PrecisaManutencao = true },
    new ModelInput { KmRodados = 8200f, DiasDesdeUltimaManutencao = 190f, PrecisaManutencao = true },

    // 51-75: altos (espera-se PRECISA)
    new ModelInput { KmRodados = 9000f, DiasDesdeUltimaManutencao = 200f, PrecisaManutencao = true },
    new ModelInput { KmRodados = 10000f, DiasDesdeUltimaManutencao = 250f, PrecisaManutencao = true },
    new ModelInput { KmRodados = 11000f, DiasDesdeUltimaManutencao = 300f, PrecisaManutencao = true },
    new ModelInput { KmRodados = 12000f, DiasDesdeUltimaManutencao = 30f, PrecisaManutencao = true },
    new ModelInput { KmRodados = 13000f, DiasDesdeUltimaManutencao = 60f, PrecisaManutencao = true },
    new ModelInput { KmRodados = 14000f, DiasDesdeUltimaManutencao = 400f, PrecisaManutencao = true },
    new ModelInput { KmRodados = 15000f, DiasDesdeUltimaManutencao = 180f, PrecisaManutencao = true },
    new ModelInput { KmRodados = 16000f, DiasDesdeUltimaManutencao = 365f, PrecisaManutencao = true },
    new ModelInput { KmRodados = 17000f, DiasDesdeUltimaManutencao = 200f, PrecisaManutencao = true },
    new ModelInput { KmRodados = 18000f, DiasDesdeUltimaManutencao = 90f, PrecisaManutencao = true },
    new ModelInput { KmRodados = 19000f, DiasDesdeUltimaManutencao = 10f, PrecisaManutencao = true },
    new ModelInput { KmRodados = 20000f, DiasDesdeUltimaManutencao = 365f, PrecisaManutencao = true },
    new ModelInput { KmRodados = 9000f, DiasDesdeUltimaManutencao = 10f, PrecisaManutencao = true },
    new ModelInput { KmRodados = 8500f, DiasDesdeUltimaManutencao = 100f, PrecisaManutencao = true },
    new ModelInput { KmRodados = 8300f, DiasDesdeUltimaManutencao = 160f, PrecisaManutencao = true },
    new ModelInput { KmRodados = 8100f, DiasDesdeUltimaManutencao = 75f, PrecisaManutencao = true },
    new ModelInput { KmRodados = 10050f, DiasDesdeUltimaManutencao = 190f, PrecisaManutencao = true },
    new ModelInput { KmRodados = 12300f, DiasDesdeUltimaManutencao = 210f, PrecisaManutencao = true },
    new ModelInput { KmRodados = 7600f, DiasDesdeUltimaManutencao = 220f, PrecisaManutencao = true },
    new ModelInput { KmRodados = 6200f, DiasDesdeUltimaManutencao = 240f, PrecisaManutencao = true },
    new ModelInput { KmRodados = 9500f, DiasDesdeUltimaManutencao = 260f, PrecisaManutencao = true },
    new ModelInput { KmRodados = 11100f, DiasDesdeUltimaManutencao = 120f, PrecisaManutencao = true },
    new ModelInput { KmRodados = 9900f, DiasDesdeUltimaManutencao = 30f, PrecisaManutencao = true },
    new ModelInput { KmRodados = 8700f, DiasDesdeUltimaManutencao = 15f, PrecisaManutencao = true },

    // 76-100: casos mistos / ruído (edge cases)
    new ModelInput { KmRodados = 250f, DiasDesdeUltimaManutencao = 200f, PrecisaManutencao = true },    // poucos km mas muitos dias
    new ModelInput { KmRodados = 18000f, DiasDesdeUltimaManutencao = 1f, PrecisaManutencao = true },   // muitos km, poucos dias
    new ModelInput { KmRodados = 400f, DiasDesdeUltimaManutencao = 180f, PrecisaManutencao = true },    // borderline
    new ModelInput { KmRodados = 600f, DiasDesdeUltimaManutencao = 150f, PrecisaManutencao = false },   // borderline
    new ModelInput { KmRodados = 4700f, DiasDesdeUltimaManutencao = 181f, PrecisaManutencao = true },   // dias ligeiramente acima do limiar
    new ModelInput { KmRodados = 4800f, DiasDesdeUltimaManutencao = 179f, PrecisaManutencao = false },  // logo abaixo
    new ModelInput { KmRodados = 7999f, DiasDesdeUltimaManutencao = 20f, PrecisaManutencao = false },   // quase alto
    new ModelInput { KmRodados = 8001f, DiasDesdeUltimaManutencao = 20f, PrecisaManutencao = true },    // logo acima
    new ModelInput { KmRodados = 0f, DiasDesdeUltimaManutencao = 365f, PrecisaManutencao = true },      // dias extremos
    new ModelInput { KmRodados = 20000f, DiasDesdeUltimaManutencao = 0f, PrecisaManutencao = true },    // km extremos
    new ModelInput { KmRodados = 3500f, DiasDesdeUltimaManutencao = 365f, PrecisaManutencao = true },
    new ModelInput { KmRodados = 3500f, DiasDesdeUltimaManutencao = 1f, PrecisaManutencao = false },
    new ModelInput { KmRodados = 999f, DiasDesdeUltimaManutencao = 199f, PrecisaManutencao = true },
    new ModelInput { KmRodados = 1001f, DiasDesdeUltimaManutencao = 199f, PrecisaManutencao = true },
    new ModelInput { KmRodados = 450f, DiasDesdeUltimaManutencao = 181f, PrecisaManutencao = true },
    new ModelInput { KmRodados = 470f, DiasDesdeUltimaManutencao = 179f, PrecisaManutencao = false },
    new ModelInput { KmRodados = 2500f, DiasDesdeUltimaManutencao = 250f, PrecisaManutencao = true },
    new ModelInput { KmRodados = 2600f, DiasDesdeUltimaManutencao = 20f, PrecisaManutencao = false },
    new ModelInput { KmRodados = 7100f, DiasDesdeUltimaManutencao = 70f, PrecisaManutencao = true },
    new ModelInput { KmRodados = 7100f, DiasDesdeUltimaManutencao = 5f, PrecisaManutencao = true },
    new ModelInput { KmRodados = 1234f, DiasDesdeUltimaManutencao = 56f, PrecisaManutencao = false },
    new ModelInput { KmRodados = 4321f, DiasDesdeUltimaManutencao = 156f, PrecisaManutencao = true },
    new ModelInput { KmRodados = 5555f, DiasDesdeUltimaManutencao = 111f, PrecisaManutencao = true },
    new ModelInput { KmRodados = 2222f, DiasDesdeUltimaManutencao = 22f, PrecisaManutencao = false },
    new ModelInput { KmRodados = 3333f, DiasDesdeUltimaManutencao = 333f, PrecisaManutencao = true }
};

var mlContext = new MLContext();
var dataView = mlContext.Data.LoadFromEnumerable(sampleData);

var pipeline = mlContext.Transforms.Concatenate("Features", nameof(ModelInput.KmRodados), nameof(ModelInput.DiasDesdeUltimaManutencao))
    .Append(mlContext.BinaryClassification.Trainers.SdcaLogisticRegression(
        // The ModelInput property PrecisaManutencao is annotated with [ColumnName("Label")],
        // so the IDataView column name is "Label". Use that as labelColumnName.
        labelColumnName: "Label",
        featureColumnName: "Features"));

Console.WriteLine("Treinando o modelo...");
var model = pipeline.Fit(dataView);
Console.WriteLine("Modelo treinado!");

mlContext.Model.Save(model, dataView.Schema, "model-manutencao.zip");
Console.WriteLine("Modelo salvo como 'model-manutencao.zip'.");