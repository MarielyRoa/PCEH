using Microsoft.AspNetCore.Mvc;
using PCEH.Application.DTOs;
using PCEH.Application.Enums;
using PCEH.Application.Repositories;
using PCEH.Application.Services;
using PCEH.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace PCEH.WebApp.Controllers
{
    public class PredictorController : Controller
    {
        private readonly SmaPredictionService _smaService;
        private readonly LinearRegressionService _lrService;
        private readonly PercentageVariationService _pvService;
        private readonly TrendDetectionService _tdService;

        public PredictorController()
        {
            _smaService = new SmaPredictionService();
            _lrService = new LinearRegressionService();
            _pvService = new PercentageVariationService();
            _tdService = new TrendDetectionService();
        }

        private void Ensure12Items(PredictorHomeViewModel model)
        {
            if (model.Consumption == null)
                model.Consumption = new List<ConsumeDto>();

            while (model.Consumption.Count < 12)
                model.Consumption.Add(new ConsumeDto());
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = new PredictorHomeViewModel();

            
            if (ConsumeRepository.Instance.Consumos.Count == 12)
                model.Consumption = ConsumeRepository.Instance.Consumos;
            else
                Ensure12Items(model);

            model.CurrentMode = PredictionModeRepository.Instance.SelectedMode.ToString();
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(PredictorHomeViewModel model)
        {
           
            ConsumeRepository.Instance.Consumos = model.Consumption;

            var errores = model.ObtenerErrores();

            if (errores.Count > 0)
            {
                foreach (var error in errores)
                    ModelState.AddModelError(string.Empty, error);

                Ensure12Items(model);
                model.CurrentMode = PredictionModeRepository.Instance.SelectedMode.ToString();
                return View(model);
            }

            var mode = PredictionModeRepository.Instance.SelectedMode;

            switch (mode)
            {
                case PredictionMode.Sma:
                    model.SmaResult = _smaService.CalculateSma(model.Consumption);
                    break;

                case PredictionMode.LinearRegression:
                    model.LinearRegressionResult = _lrService.Calculate(model.Consumption);
                    break;

                case PredictionMode.PercentageVariation:
                    model.PercentageVariationResult = _pvService.Calculate(model.Consumption);
                    break;

                case PredictionMode.TrendDetection:
                    model.TrendDetectionResult = _tdService.Calculate(model.Consumption);
                    break;
            }

            model.CurrentMode = mode.ToString();
            return View(model);
        }

        [HttpGet]
        public IActionResult Mode()
        {
            var model = new ModeSelectionViewModel
            {
                SelectedMode = PredictionModeRepository.Instance.SelectedMode.ToString()
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Mode(ModeSelectionViewModel model)
        {
            if (!string.IsNullOrEmpty(model.SelectedMode) &&
                Enum.TryParse<PredictionMode>(model.SelectedMode, out var mode))
            {
                PredictionModeRepository.Instance.SelectedMode = mode;
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Limpiar()
        {
            ConsumeRepository.Instance.Consumos = new List<ConsumeDto>();
            return RedirectToAction("Index");
        }
    }
}