using PCEH.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PCEH.Application.Services
{
    public class LinearRegressionService
    {
        public LinearRegressionDto Calculate(List<ConsumeDto> data)
        {
            var ordered = data.OrderBy(d => d.Date).ToList();

            int n = ordered.Count;

            double sumX = 0, sumY = 0, sumXY = 0, sumX2 = 0;

            for (int i = 0; i < n; i++)
            {
                double x = i + 1;
                double y = (double)ordered[i].Value;

                sumX += x;
                sumY += y;
                sumXY += x * y;
                sumX2 += x * x;

            }

            double m = (n * sumXY - sumX * sumY) / (n * sumX2 - sumX * sumX);
            double b = (sumY - m * sumX) / n;

            double nextValue = m * (n + 1) + b;

            string trend;
            if (m > 0)
            {
                trend = "La tendencia del consumo es Alcista";
            }
            else if (m < 0)
            {
                trend = "La tendencia del consumo es Bajista";

            }
            else
            {
                trend = "La tendencia del consumo es Estable";

            }
            return new LinearRegressionDto
            {
                Slope = (decimal)m,
                Intercept = (decimal)b,
                NextValue = (decimal)nextValue,
                Trend = trend
            };

        }
    }
}
