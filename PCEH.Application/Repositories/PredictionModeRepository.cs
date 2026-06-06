using PCEH.Application.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace PCEH.Application.Repositories
{
    public class PredictionModeRepository
    {
        private PredictionModeRepository() { }

        public static PredictionModeRepository Instance { get; } = new();
        public PredictionMode SelectedMode { get; set; } = PredictionMode.Sma;
    }
}
