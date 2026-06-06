using System;
using System.Collections.Generic;
using System.Text;

namespace PCEH.Application.DTOs
{
    public class LinearRegressionDto
    {
       public decimal Slope { get; set; }
       public decimal Intercept { get; set; }
       public decimal NextValue { get; set; }
       public string Trend { get; set; } = string.Empty;

    }
}
