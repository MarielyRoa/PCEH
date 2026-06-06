using PCEH.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace PCEH.Application.Services
{
    public class TrendDetectionService
    {
        public TrendDetectionDto Calculate(List<ConsumeDto> data)
        {
            var ordered = data.OrderBy(d => d.Date).ToList();

            int up = 0;
            int down = 0;
            int stable = 0;

            for (int i = 1; i < ordered.Count; i++)
            {
                decimal current = ordered[i].Value;
                decimal previous = ordered[i - 1].Value;

                if (current > previous)
                {
                    up++;
                }
                else if (current < previous)
                {
                    down++;
                }
                else
                {
                    stable++;
                }
            }

            string trend;
            if (up > down && up > stable)
            {
                trend = "Alcista";
            }
            else if (down > up && down > stable)
            {
                trend = "Bajista";
            }
            else
            {
                trend = "Estable";
            }

            return new TrendDetectionDto
            {
                UpCount = up,
                DownCount = down,
                StableCount = stable,
                Trend = trend
            };
        }
    }
}
