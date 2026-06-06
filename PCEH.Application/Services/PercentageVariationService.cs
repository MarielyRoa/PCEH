using PCEH.Application.DTOs;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace PCEH.Application.Services
{
    public class PercentageVariationService
    {
        public PercentageVariationDto Calculate(List<ConsumeDto> data) {

            var ordered = data.OrderBy(d => d.Date).ToList();
            var variations = new List<VariationDto>();

            variations.Add(new VariationDto
            {
                MonthIndex = 1,
                VariationPercent = null,
                Message = "n/a"
            });

            for (int i = 1; i < ordered.Count; i++)
            {
                decimal previous = ordered[i - 1].Value;
                decimal current = ordered[i].Value;

                if (previous == 0)
                {
                    variations.Add(new VariationDto
                    {
                        MonthIndex = i + 1,
                        VariationPercent = null,
                        Message = "No calculable, (consumo anterior = 0)"
                    });
                }
                else
                {
                    decimal variation = ((current - previous) / previous) * 100;

                    variations.Add(new VariationDto
                    {
                        MonthIndex = i + 1,
                        VariationPercent = variation,
                        Message = $"{variation:F2}%"
                    });
                }
            }

            var validVariations= variations
                .Where(v => v.VariationPercent.HasValue)
                .Select(v => v.VariationPercent!.Value)
                .ToList();

            decimal average = validVariations.Count > 0 ? validVariations.Average() : 0;

            string trend;
            if (average > 1)
            {
                trend = "El consumo general esta Aumentando";
            }
            else if (average < -1)
            {
                trend = "El consumo general esta Disminuyendo";
            }
            else
            {
                trend = "El consumo general esta Estable";
            }
            return new PercentageVariationDto
            {
                Variations = variations,
                AverageVariation = average,
                Trend = trend
            };
        }
    }
 }
