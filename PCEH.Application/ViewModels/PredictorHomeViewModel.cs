using PCEH.Application.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PCEH.Application.ViewModels
{
    public class PredictorHomeViewModel
    {
        public List<ConsumeDto> Consumption { get; set; } = new();
        public string CurrentMode { get; set; } = "";
        public SmaDto? SmaResult { get; set; }
        public LinearRegressionDto? LinearRegressionResult { get; set; }
        public PercentageVariationDto? PercentageVariationResult { get; set; }
        public TrendDetectionDto? TrendDetectionResult { get; set; }

        public List<string> ObtenerErrores()
        {
            var errores = new List<string>();

            if (Consumption == null || Consumption.Count != 12)
            {
                errores.Add("Debes ingresar exactamente 12 registros.");
                return errores;
            }

            foreach (var item in Consumption)
            {
                if (item.Date == null)
                {
                    errores.Add("Todas las fechas son obligatorias.");
                    break; 
                }
            }

            foreach (var item in Consumption)
            {
                if (item.Value < 0)
                {
                    errores.Add("No se permiten consumos negativos.");
                    break;
                }

                if (item.Value == 0)
                {
                    errores.Add("El consumo no puede ser 0.");
                    break;
                }
            }

     
            var mesesVistos = new List<string>();

            foreach (var item in Consumption)
            {
                if (item.Date == null) continue;

                string clave = item.Date.Value.Year + "-" + item.Date.Value.Month;

                if (mesesVistos.Contains(clave))
                {
                    errores.Add("No se permiten meses repetidos en el mismo año.");
                    break;
                }

                mesesVistos.Add(clave);
            }

            var fechasOrdenadas = new List<DateTime>();

            foreach (var item in Consumption)
            {
                if (item.Date != null)
                    fechasOrdenadas.Add(item.Date.Value);
            }

            fechasOrdenadas.Sort();

            for (int i = 1; i < fechasOrdenadas.Count; i++)
            {
            
                DateTime esperado = fechasOrdenadas[i - 1].AddMonths(1);

                bool mismoMes = fechasOrdenadas[i].Month == esperado.Month;
                bool mismoAnio = fechasOrdenadas[i].Year == esperado.Year;

                if (!mismoMes || !mismoAnio)
                {
                    errores.Add("Los meses deben ser consecutivos.");
                    break;
                }
            }

            return errores;
        }
    }
}