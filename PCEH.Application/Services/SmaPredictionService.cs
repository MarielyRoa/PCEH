using PCEH.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace PCEH.Application.Services
{
    public class SmaPredictionService
    {
        public SmaDto CalculateSma(List<ConsumeDto> data)
        {
       
            var ordered = data.OrderBy(d => d.Date).ToList();

            var lastThreeConsume = ordered.TakeLast(3).ToList();

            decimal average = lastThreeConsume.Sum(x => x.Value) / 3;

            decimal lastValue = ordered.Last().Value;

            string trend;

            if (average > lastValue) {
                trend = "La tencencia del consumo es Alcista";
            } else if (average < lastValue)
            {
                trend = "La tencencia del consumo es Bajista";
            }
            else
            {
                trend = "La tencencia del consumo es Estable";
            }

            return new SmaDto
            {
                Average = average,
                NextValue = average,
                Trend = trend
            };
        }
    }
}
