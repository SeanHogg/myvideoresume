﻿using System;
using Microsoft.Extensions.ML;
using Microsoft.AspNetCore.Mvc;
using MyVideoResume.ML.SentimentAnalysis.DataModels;

namespace MyVideoResume.Server.Controllers;

[Route("[controller]")]
public class SentimentController : Controller
{
    private readonly PredictionEnginePool<SampleObservation, SamplePrediction> _predictionEnginePool;

    public SentimentController(PredictionEnginePool<SampleObservation, SamplePrediction> predictionEnginePool)
    {
        // Get the ML Model Engine injected, for scoring
        _predictionEnginePool = predictionEnginePool;
    }

    [HttpGet("[action]")]
    [Route("sentimentprediction")]
    public ActionResult<float> PredictSentiment([FromQuery] string sentimentText)
    {
        // Predict sentiment using ML.NET model
        SampleObservation sampleData = new SampleObservation { Col0 = sentimentText };

        // Predict sentiment
        SamplePrediction prediction = _predictionEnginePool.Predict(sampleData);

        float percentage = CalculatePercentage(prediction.Score);

        return percentage;
    }

    public float CalculatePercentage(double value)
    {
        return 100 * (1.0f / (1.0f + (float)Math.Exp(-value)));
    }
}
